using System;
using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Models;
using CentroDePreguntasApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CentroDePreguntasApi.Repository;

public class QuestionRepository : IQuestionRepository<Question>
{
  private readonly AppDbContext _context;

  public QuestionRepository(
    AppDbContext context
  )
  {
    _context = context;    
  }
    public async Task<IEnumerable<Question>> Get()
    {
      return await _context.Questions
        .FromSqlRaw("EXEC GetAllQuestions")
        .ToListAsync();
    }

    public async Task<int> Add(string content, int userId)
    {
      return await _context.Database
      .ExecuteSqlInterpolatedAsync($"exec CreateQuestion @Content={content}, @UserId={userId}");
    }

    public async Task<int> CloseQuestion(int questionId)
    {
      return await _context.Database
      .ExecuteSqlInterpolatedAsync($"exec UpdateQuestionIsClosed @QuestionId={questionId}");
    }
}
