using GestaoPortfolioInvestimentos.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace GestaoPortfolioInvestimentos.Application.DTOs
{
    public class RegisterUserDto
    {
        /// <summary>
        /// Nome do usuário
        /// </summary>
        [Required(ErrorMessage = "O campo Username é obrigatório.")]
        public string Username { get; set; }

        /// <summary>
        /// Password do usuário
        /// </summary>
        [Required(ErrorMessage = "O campo Password é obrigatório.")]
        public string Password { get; set; }

        /// <summary>
        /// Role do usuário
        /// </summary>
        [Required(ErrorMessage = "O campo Role é obrigatório.")]
        [EnumDataType(typeof(Roles), ErrorMessage = "Role must be one of the following: Adm, Doctor, Patient.")]
        public Roles Role { get; set; }
    }
}
