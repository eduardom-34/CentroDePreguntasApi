using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentroDePreguntasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private IAnswerService<AnswerDto, AnswerInsertDto> _answerService;

        public AnswerController(
            IAnswerService<AnswerDto, AnswerInsertDto> answerService
        )
        {
            _answerService = answerService;
        }

        [HttpGet]
        public async Task<IEnumerable<AnswerDto>> Get()
        {
            return await _answerService.Get();
        }

        
        [HttpPost]
        public async Task<ActionResult<int>> Add(AnswerInsertDto answerInsertDto)
        {
            var rawsAffected = await _answerService.Add(answerInsertDto);

            if( rawsAffected == null) {
                return BadRequest(_answerService.Errors);
            }
            return rawsAffected;

        }
    }
}
