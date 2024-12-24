using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroDePreguntasApi.Models;

public class Question
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int QuestionId { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAt { get; set; }
  public bool IsClosed { get; set; } = false;
  public int UserId { get; set; }
  [ForeignKey("UserId")]
  public User User { get; set; }

}
