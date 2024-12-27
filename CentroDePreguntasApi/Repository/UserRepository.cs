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
        var user =  await _context.Users
            .FromSqlInterpolated($"exec GetUserById @UserId = {id}")
            .ToListAsync();
            
        return user.FirstOrDefault();
    }
    public async Task<User> GetByUsername(string userName)
    {
        var user = await _context.Users
        .FromSqlInterpolated($"exec GetUserByUsername @UserName = {userName}")
        .ToListAsync();

        return user.FirstOrDefault();
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

    public async Task<string> GetUsernameIfExists(string userName)
    {
        var result = await _context.Users
            .FromSqlInterpolated($"exec CheckUsernameAvailability @UserName = {userName}")
            .Select(u => u.UserName)
            .FirstOrDefaultAsync();

        return result;
    }

    public async Task<bool> CheckUserExists(string userName)
    {
        var result = await _context.Users
            .FromSqlRaw("EXEC CheckUserExists @UserName = {0}", userName)
            .ToListAsync();

        return result.Any();
    }
}
