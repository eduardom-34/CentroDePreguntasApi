using System;
using CentroDePreguntasApi.Models;
using CentroDePreguntasApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CentroDePreguntasApi.Repository;

public class UserRepository: IUserRepository<User>
{

  private readonly AppDbContext _context;

  public UserRepository(AppDbContext context){
    _context = context;
  }


    public Task<IEnumerable<User>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById(int id)
    {
        throw new NotImplementedException();
    }
    public Task Add(User entity)
    {
        throw new NotImplementedException();
    }
    public void Delete(User entity)
    {
        throw new NotImplementedException();
    }

    public Task Save()
    {
        throw new NotImplementedException();
    }

    public void Update(User entity)
    {
        throw new NotImplementedException();
    }
}
