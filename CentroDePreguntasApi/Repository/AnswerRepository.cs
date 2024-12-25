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
    public async Task<IEnumerable<Answer>> Get()
    {
      return await _context.Answers
        .FromSqlRaw("exec GetAllAnswers")
        .ToListAsync();
    }

    public async Task<IEnumerable<Answer>> GetByQuestionId(int questionId)
    {
      return await _context.Answers
        .FromSql($"exec GetAnswersByQuestionId @QuestionId={questionId}")
        .ToListAsync();
    }
    public async Task<int> Add(string content, int userId, int questionId)
    {
      return await _context.Database
      .ExecuteSqlInterpolatedAsync($"exec AddAnswer @Content={content}, @UserId={userId}, @QuestionId={questionId}");
    }

}
