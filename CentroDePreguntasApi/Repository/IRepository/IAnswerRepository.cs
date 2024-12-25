using System;

namespace CentroDePreguntasApi.Repository.IRepository;

public interface IAnswerRepository<Answer>
{
  Task<IEnumerable<Answer>> Get();
  Task<IEnumerable<Answer>> GetByQuestionId(int questionId);
  Task<int> Add(string content, int userId, int questionId);

}
