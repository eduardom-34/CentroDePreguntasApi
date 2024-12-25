using System;

namespace CentroDePreguntasApi.DTOs;

public class AnswerDto
{
  public class Answer
{
  public int AnswerId { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public int UserId { get; set; }
  public int QuestionId { get; set; }
}

}
