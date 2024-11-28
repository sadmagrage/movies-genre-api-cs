using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesGenreAPI.Dtos;
using MoviesGenreAPI.Services;
using System.Security.Claims;

namespace MoviesGenreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var movies = await _movieService.FindAll();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            var movie = _movieService.FindById(id);

            return Ok(movie);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Save([FromBody] MovieDto movieDto)
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;

            await _movieService.Save(movieDto, username);

            return Created();
        }
    }
}
