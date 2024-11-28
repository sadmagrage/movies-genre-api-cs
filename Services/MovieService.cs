using MoviesGenreAPI.Dtos;
using MoviesGenreAPI.Entities;
using MoviesGenreAPI.Repositories;

namespace MoviesGenreAPI.Services
{
    public class MovieService
    {
        private readonly MovieRepository _movieRepository;
        private readonly UserService _userService;
        private readonly GenreService _genreService;

        public MovieService(MovieRepository movieRepository, UserService userService, GenreService genreService)
        {
            _movieRepository = movieRepository;
            _userService = userService;
            _genreService = genreService;
        }

        public async Task<List<Movie>> FindAll()
        {
            return await _movieRepository.FindAll();
        }

        public async Task<Movie> FindById(Guid id)
        {
            return await _movieRepository.FindById(id);
        }

        public async Task Save(MovieDto movieDto, string username)
        {
            var user = await _userService.FindUserByUsername(username);

            if (user.Equals(null)) throw new Exception("Forbidden");

            var genres = await _genreService.FindGenresById(movieDto.Genres);

            //TEM Q FAZER A CHECAGEM DE CADA GENRE QUE EXISTE, E PASSAR UMA NOVA INSTANCIA DE MOVIE_GENRE CADA UM SERA UMA CRIACAO

            var movie = new Movie
            {
                Duration = movieDto.Duration,
                MovieGenres = genres,
                Image = movieDto.Image,
                Rating = movieDto.Rating,
                Release = movieDto.Release,
                Synopsis = movieDto.Synopsis,
                Title = movieDto.Title,
                User = user
            };

            await _movieRepository.Save(movie);
        }
    }
}
