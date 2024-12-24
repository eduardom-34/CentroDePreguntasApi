using System;

namespace CentroDePreguntasApi.Services.IServices;

public interface IUserServices<UserDto, UserInsertDto>
{
  public List<string> Errors{ get; }

  Task<IEnumerable<UserDto>> Get();
  Task<UserDto> GetById(int id);
}
