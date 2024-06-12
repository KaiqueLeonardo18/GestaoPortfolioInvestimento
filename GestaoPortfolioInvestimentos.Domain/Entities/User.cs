
using GestaoPortfolioInvestimentos.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text.Json.Serialization;

namespace GestaoPortfolioInvestimentos.Domain.Entities
{
    public class User
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        [JsonIgnore]
        public string Password { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        [EnumDataType(typeof(Roles))]
        public Roles Role { get; set; }
    }
}
