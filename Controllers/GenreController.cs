using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesGenreAPI.Dtos;
using MoviesGenreAPI.Services;

namespace MoviesGenreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GenreService _genreService;

        public GenreController(GenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var genres = await _genreService.FindAll();

            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            var genre = await _genreService.FindByIdWithMovie(id);

            return Ok(genre);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Save([FromBody] GenreDto genreDto)
        {
            await _genreService.Save(genreDto);

            return Created();
        }
    }
}
