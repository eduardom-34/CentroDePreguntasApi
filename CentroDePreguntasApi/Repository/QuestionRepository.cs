using System;
using CentroDePreguntasApi.Models;
using CentroDePreguntasApi.Repository.IRepository;

namespace CentroDePreguntasApi.Repository;

public class QuestionRepository : IQuestionRepository<Question>
{
    public Task<IEnumerable<Question>> Get()
    {
        throw new NotImplementedException();
    }
}
