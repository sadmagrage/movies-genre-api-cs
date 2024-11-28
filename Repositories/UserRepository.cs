using Microsoft.EntityFrameworkCore;
using MoviesGenreAPI.Context;
using MoviesGenreAPI.Entities;

namespace MoviesGenreAPI.Repositories
{
    public class UserRepository
    {
        private readonly MoviesGenreAPIContext _context;

        public UserRepository(MoviesGenreAPIContext context)
        {
            _context = context;
        }

        public async Task<User> FindUserByUsername(string username)
        {
            return await _context.User.Where(user => user.Username.Equals(username)).FirstOrDefaultAsync();
        }

        public async Task SaveUser(User user)
        {
            await _context.User.AddAsync(user);

            await _context.SaveChangesAsync();
        }
    }
}
