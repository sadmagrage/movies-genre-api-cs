using Microsoft.EntityFrameworkCore;
using MoviesGenreAPI.Context;
using MoviesGenreAPI.Entities;

namespace MoviesGenreAPI.Repositories
{
    public class MovieRepository
    {
        private readonly MoviesGenreAPIContext _context;

        public MovieRepository(MoviesGenreAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> FindAll()
        {
            return await _context.Movie.Select(movie => new Movie
            {
                Duration = movie.Duration,
                Genres = movie.Genres,
                Id = movie.Id,
                Image = movie.Image,
                Rating = movie.Rating,
                Release = movie.Release,
                Synopsis = movie.Synopsis,
                Title = movie.Title,
                User = movie.User,
            }).ToListAsync();
        }

        public async Task<Movie> FindById(Guid id)
        {
            return await _context.Movie.Select(movie => new Movie
            {
                Duration = movie.Duration,
                Genres = movie.Genres,
                Id = movie.Id,
                Image = movie.Image,
                Rating = movie.Rating,
                Release = movie.Release,
                Synopsis = movie.Synopsis,
                Title = movie.Title,
                User = movie.User,
            })
                .Where(movie => movie.Id.Equals(id))
                    .FirstOrDefaultAsync();
        }

        public async Task Save(Movie movie)
        {
            await _context.Movie.AddAsync(movie);

            await _context.SaveChangesAsync();
        }
    }
}
