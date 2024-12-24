using System;
using Microsoft.EntityFrameworkCore;

namespace CentroDePreguntasApi.Models;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
  {}

  public DbSet<User> Users { get; set; }
  public DbSet<Question> Questions { get; set; }
  public DbSet<Answer> Answers { get; set; }
}
