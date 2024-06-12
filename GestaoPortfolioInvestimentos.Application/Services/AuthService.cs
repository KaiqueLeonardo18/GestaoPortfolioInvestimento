using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Application.Interfaces;
using GestaoPortfolioInvestimentos.Domain.Entities;
using GestaoPortfolioInvestimentos.Domain.Enums;
using GestaoPortfolioInvestimentos.Infrastructure.Interfaces;

namespace GestaoPortfolioInvestimentos.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passwordHasher;
        public AuthService(IUserRepository userRepository, ITokenService tokenService, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> RegisterAsync(RegisterUserDto dto)
        {
            var user = new User { Username = dto.Username, Role = dto.Role, Email = dto.email};
 
            user.Password = _passwordHasher.HashPassword(dto.Password);
            var result = await _userRepository.CreateAsync(user);

            return result;
        }

        public async Task<bool> ExistsUser(string username)
        {
            if (await _userRepository.ExistsUser(username))
            {
                return true;
            }

            return false;
        }

        public async Task<User> LoginAsync(AuthenticateRequest dto)
        {
            var user = await _userRepository.GetByUsername(dto.Username);

            if (user == null)
            {
                return null;
            }
            return user;
        }

        public bool VerificarPassword(string senhaDto, string passwordUser)
        {
            if (!_passwordHasher.VerificarPassword(senhaDto, passwordUser))
            {
                return false;
            }

            return true;
        }

        public async Task<string> GenerateToken(User user)
        {
            return await _tokenService.GenerateToken(user);
        }
    }
}
