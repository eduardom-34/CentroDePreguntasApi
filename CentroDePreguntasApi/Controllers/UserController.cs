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
    }
}
