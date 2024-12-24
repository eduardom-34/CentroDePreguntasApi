using System;
using AutoMapper;
using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Models;

namespace CentroDePreguntasApi.AutoMappers;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    // Mapping for users
    // Origin of info, returning info
    CreateMap<UserInsertDto, User>();
    CreateMap<User, UserDto>();
    
  }
}
