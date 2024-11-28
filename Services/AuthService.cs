using MoviesGenreAPI.Dtos;

namespace MoviesGenreAPI.Services
{
    public class AuthService
    {
        private readonly UserService _userService;
        private readonly TokenService _tokenService;

        public AuthService(UserService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<TokenDto> Login(LoginDto loginDto)
        {
            var user = await _userService.FindUserByUsername(loginDto.Username);

            if (user == null) throw new Exception();

            var tokenStr = _tokenService.GenerateToken(user.Username, user.Role);

            return new TokenDto
            {
                Token = tokenStr
            };
        }
    }
}
