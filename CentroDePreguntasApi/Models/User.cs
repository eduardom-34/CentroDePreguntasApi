using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroDePreguntasApi.Models;

public class User
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int UserId { get; set; }
  public string UserName { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public byte[] PasswordHash { get; set; }
  public byte[] PasswordSalt { get; set; }
  public ICollection<Question> Questions { get; set; } = new List<Question>();
  public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}
