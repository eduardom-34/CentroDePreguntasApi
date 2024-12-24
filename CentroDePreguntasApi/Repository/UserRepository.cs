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

    public async Task<IEnumerable<User>> Get()
    {
        return await _context.Users
            .FromSqlRaw("EXEC GetAllUsers")
            .ToListAsync();
    }

    public async Task<User> GetById(int id)
    {
        return await _context.Users
            .FromSqlRaw("EXEC GetUserById @UserId = {0}", id)
            .FirstOrDefaultAsync();
    }
    public async Task<int> Add(User user)
    {
        return await _context.Database
        .ExecuteSqlInterpolatedAsync($"exec AddUser @UserName={user.UserName}, @FirstName={user.FirstName}, @LastName={user.LastName}, @PasswordHash={user.PasswordHash}, @PasswordSalt={user.PasswordSalt}");
    }
    public void Delete(int userId)
    {
        _context.Users
            .FromSqlRaw("exec DeleteUser @UserId = {0}", userId)
            .ToList();
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
