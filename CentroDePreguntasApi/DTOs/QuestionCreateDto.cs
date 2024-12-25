using System;
using CentroDePreguntasApi.Models;

namespace CentroDePreguntasApi.DTOs;

public class QuestionCreateDto
{
  public string Content { get; set; }
  public int UserId { get; set; }
}
