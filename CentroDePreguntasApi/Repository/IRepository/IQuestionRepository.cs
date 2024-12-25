using System;
using CentroDePreguntasApi.Models;

namespace CentroDePreguntasApi.Repository.IRepository;

public interface IQuestionRepository<Question>
{
  Task<IEnumerable<Question>> Get();
}
