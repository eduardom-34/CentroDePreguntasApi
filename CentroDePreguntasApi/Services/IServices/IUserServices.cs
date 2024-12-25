using System;
using CentroDePreguntasApi.DTOs;

namespace CentroDePreguntasApi.Services.IServices;

public interface IUserServices<UserDto, UserInsertDto, UserTokenDto>
{
  public List<string> Errors{ get; }
  Task<IEnumerable<UserDto>> Get();
  Task<UserDto> GetByUsername(string username);
  Task<UserDto> GetById(int id);
  Task<UserTokenDto> Add(UserInsertDto userInsertDto);
  Task<UserTokenDto> Login(string userName, string password);
  UserTokenDto ValidateToken(string token);
  
}
