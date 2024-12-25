using System;
using AutoMapper;
using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CentroDePreguntasApi.AutoMappers;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    // Mapping for users
    // Origin of info, returning info
    CreateMap<UserInsertDto, User>();
    CreateMap<User, UserDto>();

    // Mapping for questions
    CreateMap<QuestionInsertDto, Question>();
    CreateMap<Question, QuestionDto>()
      .ForMember(dest => dest.QuestionUserId, opt => opt.MapFrom(src => src.UserId));

    // Mappping for Answers
    CreateMap<Answer, AnswerDto>();
  }
}
