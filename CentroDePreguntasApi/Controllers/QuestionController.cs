using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Models;
using CentroDePreguntasApi.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentroDePreguntasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionService<QuestionDto, QuestionInsertDto> _questionService;

        public QuestionController(
            IQuestionService<QuestionDto, QuestionInsertDto> questionService
        )
        {
            _questionService = questionService;
        }

        // [Authorize]
        [HttpGet]
        public async Task<IEnumerable<QuestionDto>> Get()
        {
            return await _questionService.Get();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add(QuestionInsertDto questionInsertDto)
        {
            var affectedRows = await _questionService.Add(questionInsertDto);

            if( affectedRows == null) {
                return BadRequest();
            }

            return affectedRows;
        }
    }
}
