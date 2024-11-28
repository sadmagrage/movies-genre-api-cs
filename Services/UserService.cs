using MoviesGenreAPI.Dtos;
using MoviesGenreAPI.Entities;
using MoviesGenreAPI.Repositories;

namespace MoviesGenreAPI.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> FindUserByUsername(string username)
        {
            return await _userRepository.FindUserByUsername(username);
        }

        public async Task SaveUser(UserDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password, 12),
                Role = "USER"
            };

            await _userRepository.SaveUser(user);
        }
    }
}
