using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
      var claims = new List<Claim>
      {
        new Claim(JwtRegisteredClaimNames.NameId, userDto.UserName)
      };

      var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddMinutes(30),
        SigningCredentials = creds
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
        throw new NotImplementedException();
    }
}
