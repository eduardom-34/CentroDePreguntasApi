using System;
using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Models;
using CentroDePreguntasApi.Repository.IRepository;
using CentroDePreguntasApi.Services.IServices;

namespace CentroDePreguntasApi.Services;

public class UserServices : IUserServices<UserDto, UserInsertDto>
{
  private IUserRepository<User> _userRepository;

  public List<string> Errors { get; }

  public UserServices( IUserRepository<User> userRepository)
  {
    _userRepository = userRepository;    
  }

    public async Task<IEnumerable<UserDto>> Get()
    {
      var users = await _userRepository.Get();
      return null;
    }

    public Task<UserDto> GetById(int id)
    {
        throw new NotImplementedException();
    }
}
