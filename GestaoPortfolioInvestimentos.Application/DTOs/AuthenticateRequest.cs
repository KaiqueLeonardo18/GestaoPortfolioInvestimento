using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Application.DTOs
{
    public class AuthenticateRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
