using MoviesGenreAPI.Dtos;
using MoviesGenreAPI.Entities;
using MoviesGenreAPI.Repositories;

namespace MoviesGenreAPI.Services
{
    public class GenreService
    {
        private readonly GenreRepository _genreRepository;

        public GenreService(GenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<List<Genre>> FindAll()
        {
            return await _genreRepository.FindAll();
        }

        public async Task<Genre> FindByIdWithMovie(Guid id)
        {
            return await _genreRepository.FindByIdWithMovie(id);
        }

        public async Task<List<Genre>> FindGenresById(List<Guid> ids)
        {
            return await _genreRepository.FindGenresById(ids);
        }

        public async Task Save(GenreDto genreDto)
        {
            var genre = new Genre
            {
                Name = genreDto.Name,
            };

            await _genreRepository.Save(genre);
        }
    }
}
