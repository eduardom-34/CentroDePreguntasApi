using System;
using CentroDePreguntasApi.Models;
using CentroDePreguntasApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CentroDePreguntasApi.Repository;

public class AnswerRepository : IAnswerRepository<Answer>
{
  private readonly AppDbContext _context;

  public AnswerRepository(
    AppDbContext context
  )
  {
    _context = context;
  }
    public Task<IEnumerable<Answer>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Answer>> GetByQuestionId(int questionId)
    {
        throw new NotImplementedException();
    }
    public async Task<int> Add(string content, int userId, int questionId)
    {
      return await _context.Database
      .ExecuteSqlInterpolatedAsync($"exec AddAnswer @Content={content}, @UserId={userId}, @QuestionId={questionId}");
    }

}
