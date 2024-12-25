using System;
using CentroDePreguntasApi.Models;

namespace CentroDePreguntasApi.DTOs;

public class QuestionDto
{
  public int QuestionId { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAt { get; set; }
  public bool IsClosed { get; set; } = false;
  public int UserId { get; set; }
  public ICollection<Answer> Answers { get; set; }
}
