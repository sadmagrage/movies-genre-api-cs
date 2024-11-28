using Microsoft.EntityFrameworkCore;
using MoviesGenreAPI.Context;
using MoviesGenreAPI.Entities;

namespace MoviesGenreAPI.Repositories
{
    public class GenreRepository
    {
        private readonly MoviesGenreAPIContext _context;

        public GenreRepository(MoviesGenreAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> FindAll()
        {
            return await _context.Genre.Select(genre => new Genre
            {
                Id = genre.Id,
                Name = genre.Name
            }).ToListAsync();
        }

        public async Task<Genre> FindByIdWithMovie(Guid id)
        {
            return await _context.Genre.Select(genre => new Genre
            {
                Id = genre.Id,
                Name = genre.Name,
                Movies = genre.Movies
            })
                .Where(genre => genre.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Genre>> FindGenresById(List<Guid> ids)
        {
            return await _context.Genre.Select(genre => new Genre
            {
                Id = genre.Id,
                Name = genre.Name,
            })
                .Where(genre => ids.Contains(genre.Id))
                .ToListAsync();
        }

        public async Task Save(Genre genre)
        {
            await _context.Genre.AddAsync(genre);

            await _context.SaveChangesAsync();
        }
    }
}
