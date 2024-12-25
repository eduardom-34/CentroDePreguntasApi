using System;
using CentroDePreguntasApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CentroDePreguntasApi.Services.IServices;

public interface IAnswerService<AnswerDto, AnswerInsertDto>
{
  public List<string> Errors { get; }
  public Task<IEnumerable<AnswerDto>> Get();
  public Task<IEnumerable<AnswerDto>> GetByQuestionId(int id);
  public Task<ActionResult<int>> Add(AnswerInsertDto answerInsertDto);
 
}
