using System;

namespace CentroDePreguntasApi.Services.IServices;

public interface ITokenService<UserDto>
{
  string CreateToken(UserDto userDto);
  bool ValidateToken(string token);
  string GetUserFromToken(string token);
}
