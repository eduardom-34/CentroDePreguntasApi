using System;
using Microsoft.AspNetCore.Mvc;

namespace CentroDePreguntasApi.Services.IServices;

public interface IQuestionService<QuestionDto, QuestionInsertDto>
{
  public List<string> Errors{ get; }
  public Task<IEnumerable<QuestionDto>> Get();
  public Task<ActionResult<int>> Add(QuestionInsertDto questionInsertDto);

}
