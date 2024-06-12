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
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        /// <summary>
        /// Produto Financeiro
        /// </summary>
        public ProdutoFinanceiro ProdutoFinanceiro { get; set; }

        /// <summary>
        /// ProdutoFinanceiroId
        /// </summary>
        [JsonIgnore]
        public int ProdutoFinanceiroId { get; set; }

        /// <summary>
        /// User
        /// </summary>
        [JsonIgnore]
        public User User { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        [JsonIgnore]
        public int UserId { get; set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        public decimal Quantidade { get; set; }

        /// <summary>
        /// DataTransacao
        /// </summary>
        public DateTime DataTransacao { get; set; }

        public ClienteInvestimento()
        {
            DataTransacao = DateTime.Now;
        }
    }
}
