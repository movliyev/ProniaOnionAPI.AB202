using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion202.Applicatin.Abstractions.Services;
using ProniaOnion202.Applicatin.DTOs.Users;

namespace ProniaOnion202.AB202API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly IUserService _ser;

        public UsersController(IUserService ser)
        {
            _ser = ser;
        }
        [HttpPost]
        public async Task<IActionResult>Registr([FromForm]RegistrDto dto)
        {
            await _ser.Registr(dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> Login([FromForm]LoginDto dto)
        {
            return StatusCode(StatusCodes.Status200OK,await _ser.Login(dto));
        }
    }
}
