using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Application.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegisterUserDto registrarUser);

        Task<User> LoginAsync(AuthenticateRequest user);

        Task<string> GenerateToken(User user);

        bool VerificarPassword(string senhaDto, string passwordUser);
    }
}
