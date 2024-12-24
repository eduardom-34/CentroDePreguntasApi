using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroDePreguntasApi.Models;

public class Answer
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int AnswerId { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  
  public int UserId { get; set; }
  [ForeignKey("UserId")]
  public User User { get; set; }

  public int QuestionId { get; set; }
  [ForeignKey("QuestionId")]
  public Question Question { get; set; }
}
