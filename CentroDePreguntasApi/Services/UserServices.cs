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
  private IMapper _mapper;

  public List<string> Errors { get; }

  public UserServices( 
    IUserRepository<User> userRepository,
    IMapper mapper)
  {
    _userRepository = userRepository;
    _mapper = mapper;
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

    public async Task<UserTokenDto> Add(UserInsertDto userInsertDto)
    {

      using var hmac = new HMACSHA512();

      var user = _mapper.Map<User>(userInsertDto);
      user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userInsertDto.Password));
      user.PasswordSalt = hmac.Key;

      await _userRepository.Add(user);

      var userDto = _mapper.Map<UserDto>(user);
      var userTokenDto = new UserTokenDto
      {
        UserName = user.UserName,
        Token = "asas"
      };

      return userTokenDto;


    }
}
