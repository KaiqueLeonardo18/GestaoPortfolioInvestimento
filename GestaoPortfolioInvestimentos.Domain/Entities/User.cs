
using GestaoPortfolioInvestimentos.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text.Json.Serialization;

namespace GestaoPortfolioInvestimentos.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [EnumDataType(typeof(Roles))]
        public Roles Role { get; set; }
    }
}
