using CentroDePreguntasApi.AutoMappers;
using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Models;
using CentroDePreguntasApi.Repository;
using CentroDePreguntasApi.Repository.IRepository;
using CentroDePreguntasApi.Services;
using CentroDePreguntasApi.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Base de Datos, Entity Framework
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
});

// Add Repository
builder.Services.AddScoped<IUserRepository<User>, UserRepository>();




// Add services
builder.Services.AddScoped<IUserServices<UserDto, UserInsertDto, UserTokenDto>, UserServices>();


// Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
