using GestaoPortfolioInvestimentos.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace GestaoPortfolioInvestimentos.Application.DTOs
{
    public class RegisterUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        [Required]
        [EnumDataType(typeof(Roles), ErrorMessage = "Role must be one of the following: Adm, Doctor, Patient.")]
        public Roles Role { get; set; }
    }
}
