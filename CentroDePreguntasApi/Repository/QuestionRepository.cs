using System;
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
      .FromSqlRaw("exec GetAllQuestions")
      .ToListAsync();
    }

    public Task<ActionResult<Question>> Add()
    {
        throw new NotImplementedException();
    }
}
