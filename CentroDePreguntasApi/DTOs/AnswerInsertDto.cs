using System;

namespace CentroDePreguntasApi.DTOs;

public class AnswerInsertDto
{
  public string Content { get; set; }
  public int UserId { get; set; }
  public int QuestionId { get; set; }
}
