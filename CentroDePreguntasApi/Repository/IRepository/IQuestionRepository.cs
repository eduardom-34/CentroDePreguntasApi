using System;
using CentroDePreguntasApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CentroDePreguntasApi.Repository.IRepository;

public interface IQuestionRepository<Question>
{
  Task<IEnumerable<Question>> Get();
  Task<ActionResult<Question>> Add();
}
