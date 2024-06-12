using GestaoPortfolioInvestimentos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Domain.Entities
{
    public class ClienteInvestimento
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public ProdutoFinanceiro ProdutoFinanceiro { get; set; }
        [JsonIgnore]
        public int ProdutoFinanceiroId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataTransacao { get; set; }

        public ClienteInvestimento()
        {
            DataTransacao = DateTime.Now;
        }
    }
}
