using System;
using System.Text;
using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Services.IServices;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;

namespace CentroDePreguntasApi.Services;

public class TokenService : ITokenService<UserDto>
{
  private readonly SymmetricSecurityKey _key;

  public TokenService( IConfiguration config )
  {
    var tokenKey = config["TokenKey"];

    if (string.IsNullOrEmpty(tokenKey))
    {
      throw new ArgumentNullException(nameof(tokenKey), "TokenKey configuration is missing or empty.");
    }

    _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
  }
    public string CreateToken(UserDto userDto)
    {
        throw new NotImplementedException();
    }

    public bool ValidateToken(string token)
    {
        throw new NotImplementedException();
    }
}
