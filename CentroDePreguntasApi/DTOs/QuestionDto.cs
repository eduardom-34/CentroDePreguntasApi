using System;
using CentroDePreguntasApi.Models;

namespace CentroDePreguntasApi.DTOs;

public class QuestionDto
{
  public int QuestionId { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAt { get; set; }
  public bool IsClosed { get; set; } = false;
  public int QuestionUserId { get; set; }
  public string FirstName { get; set; } // Información adicional del usuario
  public string LastName { get; set; }
  public string UserName { get; set; }
  public ICollection<Answer> Answers { get; set; }
}
