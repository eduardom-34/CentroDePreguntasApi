using System;

namespace CentroDePreguntasApi.DTOs;

public class UserDto
{
  public int UserId { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string UserName { get; set; }
  public byte[] PasswordHash { get; set; }
  public byte[] PasswordSalt { get; set; }
}
