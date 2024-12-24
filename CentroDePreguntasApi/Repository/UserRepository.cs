using System;
using CentroDePreguntasApi.Models;
using CentroDePreguntasApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CentroDePreguntasApi.Repository;

public class UserRepository: IUserRepository
{

  private readonly AppDbContext _context;

  public UserRepository(AppDbContext context){
    _context = context;
  }

}
