using System;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Models;
using CentroDePreguntasApi.Repository.IRepository;
using CentroDePreguntasApi.Services.IServices;
using Microsoft.IdentityModel.Tokens;

namespace CentroDePreguntasApi.Services;

public class UserServices : IUserServices<UserDto, UserInsertDto, UserTokenDto>
{
  private IUserRepository<User> _userRepository;
  private ITokenService<UserDto> _tokenService;
  private IMapper _mapper;

  public List<string> Errors { get; }

  public UserServices( 
    IUserRepository<User> userRepository,
    IMapper mapper,
    ITokenService<UserDto> tokenService)
  {
    _userRepository = userRepository;
    _tokenService = tokenService;
    _mapper = mapper;
    Errors = new List<string>();
  }

    public async Task<IEnumerable<UserDto>> Get()
    {
      var users = await _userRepository.Get();
      return users.Select(u => _mapper.Map<UserDto>(u));
    }

    public async Task<UserDto> GetById(int id)
    {
      var user = await _userRepository.GetById(id);

      if( user != null) {
        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
      }

      return null;
    }
    public async Task<UserDto> GetByUsername(string username)
    {
      var user = await _userRepository.GetByUsername(username);

      if( user != null){
        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
      }

      return null;
    }

    public async Task<UserTokenDto> Add(UserInsertDto userInsertDto)
    {

      using var hmac = new HMACSHA512();

      var user = _mapper.Map<User>(userInsertDto);
      user.UserName = userInsertDto.UserName.ToLower();
      user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userInsertDto.Password));
      user.PasswordSalt = hmac.Key;

      await _userRepository.Add(user);

      var userDto = _mapper.Map<UserDto>(user);
      var userTokenDto = new UserTokenDto
      {
        UserName = user.UserName,
        Token = _tokenService.CreateToken(userDto)
      };

      return userTokenDto;


    }

    public async Task<UserTokenDto> Login(string userName, string password)
    {
      var user = await _userRepository.GetByUsername(userName);

      if(user != null)
      {

      

        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash![i])
                {
                    Errors.Add("The password is incorret, please try again");
                    return null;
                }
            }
        var userDto = _mapper.Map<UserDto>(user);

        var userTokenDto = new UserTokenDto
        {
          UserName = user.UserName,
          Token = _tokenService.CreateToken(userDto)
        };

        return userTokenDto;
      }
      
      Errors.Add("This username does not exist, please try again or create an account");
        return null;
    }

    public UserTokenDto ValidateToken(string token)
    {
      if (string.IsNullOrEmpty(token)) return null;

        var validationResult = _tokenService.ValidateToken(token);

        if( validationResult == false )
        {
            Errors.Add("This  token is invalid");
            return null;
        }

        var username = _tokenService.GetUserFromToken(token);

        var UserTokenDto = new UserTokenDto
        {
            UserName = username,
            Token = token
        };

        return UserTokenDto;
    }
}
