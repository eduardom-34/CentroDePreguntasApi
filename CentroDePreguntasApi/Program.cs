using System.Text;
using CentroDePreguntasApi.AutoMappers;
using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Models;
using CentroDePreguntasApi.Repository;
using CentroDePreguntasApi.Repository.IRepository;
using CentroDePreguntasApi.Services;
using CentroDePreguntasApi.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Base de Datos, Entity Framework
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
});

// JWT
builder.Services.AddScoped<ITokenService<UserDto>, TokenService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                     .AddJwtBearer(options =>
                     {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["tokenKey"]!)),
                         ValidateIssuer = false,
                         ValidateAudience = false
                       };
                     });

// Add Repository
builder.Services.AddScoped<IUserRepository<User>, UserRepository>();
builder.Services.AddScoped<IQuestionRepository<Question>, QuestionRepository>();



// Add services
builder.Services.AddScoped<IUserServices<UserDto, UserInsertDto, UserTokenDto>, UserServices>();
builder.Services.AddScoped<IQuestionService<QuestionDto, QuestionInsertDto> , QuestionService>();

// Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
      options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
        Description = "Add Bearer [space] token \r\n\r\n "
                      + "Example: Bearer [space] 1234567890",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
      });
      options.AddSecurityRequirement(new OpenApiSecurityRequirement(){
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
    });

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
