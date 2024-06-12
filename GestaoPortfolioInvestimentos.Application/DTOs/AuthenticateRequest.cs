using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Application.DTOs
{
    public class AuthenticateRequest
    {
        [Required(ErrorMessage = "O campo Username é obrigatório.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Password é obrigatório.")]
        public string Password { get; set; }
    }
}
