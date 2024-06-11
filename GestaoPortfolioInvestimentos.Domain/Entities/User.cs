
using System.ComponentModel.DataAnnotations;
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
        public string Role { get; set; }
    }
}
