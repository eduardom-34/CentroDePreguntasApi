using System;
using AutoMapper;
using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Models;
using CentroDePreguntasApi.Repository.IRepository;
using CentroDePreguntasApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CentroDePreguntasApi.Services;

public class QuestionService : IQuestionService<QuestionDto, QuestionInsertDto>
{
  private readonly IQuestionRepository<Question> _questionRepository;
  private IMapper _mapper;

  public List<string> Errors { get; }

  public QuestionService(
    IQuestionRepository<Question> questionRepository,
    IMapper mapper
  )
  {
    _questionRepository = questionRepository;
    _mapper = mapper;
    Errors = new List<string>();
    
  }
    public async Task<IEnumerable<QuestionDto>> Get()
    {
      var questions = await _questionRepository.Get();

      return questions.Select( q => _mapper.Map<QuestionDto>(q) );

    }
    public async Task<ActionResult<int>> Add(QuestionInsertDto questionInsertDto)
    {
      var affectedRows = await _questionRepository.Add(questionInsertDto.Content, questionInsertDto.UserId);

      if( affectedRows == 0){
        return null;
      }

      return affectedRows;
      // return question;
    }

    public Task<int> CloseQuestion(int questionId)
    {
      var affectedRows = _questionRepository.CloseQuestion(questionId);

      return affectedRows;
    }
}
