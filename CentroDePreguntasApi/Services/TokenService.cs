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

    public string GetUserFromToken(string token)
    {
      if (string.IsNullOrEmpty(token)) return null;

    var tokenHandler = new JwtSecurityTokenHandler();

    var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
    
    if (jwtToken == null)
        return null;

    
    var nameid = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId)?.Value;

    return nameid;

    }

    public bool ValidateToken(string token)
    {
      if (string.IsNullOrEmpty(token))
      return false;

    var tokenHandler = new JwtSecurityTokenHandler();

    if (!tokenHandler.CanReadToken(token))
      return false;

    var validationParameters = new TokenValidationParameters
    {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = _key,
      ValidateIssuer = false,
      ValidateAudience = false
    };
    
    try
    {
        tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
        return validatedToken != null; 
    }
    catch (SecurityTokenException)
    {
        return false;
    }
    catch (Exception)
    {
        // hanlde other erros if needed
        return false;
    }
    }
}
