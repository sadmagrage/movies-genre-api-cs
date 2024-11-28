using Microsoft.AspNetCore.Mvc;
using MoviesGenreAPI.Dtos;
using MoviesGenreAPI.Services;

namespace MoviesGenreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            return Ok(await _authService.Login(loginDto));
        }
    }
}
