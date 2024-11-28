using Microsoft.AspNetCore.Mvc;
using MoviesGenreAPI.Dtos;
using MoviesGenreAPI.Services;

namespace MoviesGenreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> SaveUser([FromBody] UserDto userDto)
        {
            await _userService.SaveUser(userDto);

            return Created();
        }
    }
}
