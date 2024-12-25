using System;
using CentroDePreguntasApi.Models;

namespace CentroDePreguntasApi.DTOs;

public class QuestionInsertDto
{
  public string Content { get; set; }
  public int UserId { get; set; }
}
