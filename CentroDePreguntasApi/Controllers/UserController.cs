using CentroDePreguntasApi.DTOs;
using CentroDePreguntasApi.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentroDePreguntasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices<UserDto, UserInsertDto, UserTokenDto> _userService;
        public UserController(
            IUserServices<UserDto, UserInsertDto, UserTokenDto> userService
        )
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get() =>
        await _userService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var userDto = await _userService.GetById(id);
            if (userDto == null)
            {
                return NotFound();
            }

            return userDto;
        }

        [HttpGet("search/{username}")]
        public async Task<ActionResult<UserDto>> GetByUsername(string username)
        {
            var userDto = await _userService.GetByUsername(username);

            return userDto == null ? NotFound() : Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Add(UserInsertDto userInsertDto)
        {
            var userTokenDto = await _userService.Add(userInsertDto);

            return CreatedAtAction(nameof(GetByUsername), new { username = userTokenDto.UserName }, userTokenDto);
        }
    }
}
