using System;
using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CentroDePreguntasApi.Repository.IRepository;

public interface IQuestionRepository<Question>
{
  Task<IEnumerable<Question>> Get();
  Task<int> Add(string content, int userId);
  Task<int> CloseQuestion(int questionId);
}
