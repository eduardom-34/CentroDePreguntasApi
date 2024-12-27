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

        // [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] QuestionInsertDto questionInsertDto)
        {
            var affectedRows = await _questionService.Add(questionInsertDto);

            if( affectedRows == null) {
                return BadRequest();
            }
            return affectedRows;
        }

        [HttpPatch("{questionId}")]
        public async Task<ActionResult<int>> CloseQuestion(int questionId)
        {
            var affectedRows = await _questionService.CloseQuestion(questionId);

            if( affectedRows == 0 ) {
                return BadRequest(affectedRows);
            }
            return affectedRows;
            
        }
    }
}
