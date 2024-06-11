using GestaoPortfolioInvestimentos.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Domain.Entities
{
    public class TransacaoInvestimento
    {
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        public User User { get; set; }
        [JsonIgnore]
        public int ProdutoFinanceiroId { get; set; }
        public ProdutoFinanceiro ProdutoFinanceiro { get; set; }
        public DateTime DataTransacao { get; set; }
        public decimal Quantidade { get; set; }
        public TipoTransacao TipoTransacao { get; set; }

        public TransacaoInvestimento()
        {
            DataTransacao = DateTime.Now;
        }
    }


}
