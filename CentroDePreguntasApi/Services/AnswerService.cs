using System;
using AutoMapper;
using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Models;
using CentroDePreguntasApi.Repository.IRepository;
using CentroDePreguntasApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CentroDePreguntasApi.Services;

public class AnswerService: IAnswerService<AnswerDto, AnswerInsertDto>
{
  private readonly IAnswerRepository<Answer> _answerRepository;
  private IMapper _mapper;
  public List<string> Errors { get; }

  public AnswerService(
    IAnswerRepository<Answer> answerRepository,
    IMapper mapper
  ){
    _answerRepository = answerRepository;
    Errors = new List<string>();
    _mapper = mapper;
  }

  
    public async Task<IEnumerable<AnswerDto>> Get()
    {
        var answers = await _answerRepository.Get();

        return answers.Select(a => _mapper.Map<AnswerDto>(a));
    }
    public async Task<IEnumerable<AnswerDto>> GetByQuestionId(int id)
    {
      var answers = await _answerRepository.GetByQuestionId(id);

        return answers.Select(a => _mapper.Map<AnswerDto>(a));
    }

    public async Task<ActionResult<int>> Add(AnswerInsertDto answerInsertDto)
    {
      var rawsAffected = await _answerRepository.Add(answerInsertDto.Content, answerInsertDto.UserId, answerInsertDto.QuestionId);

      if( rawsAffected == 0){
        Errors.Add("Error al agregar respuesta");
        return null;
      }
      return rawsAffected;
    }

}
