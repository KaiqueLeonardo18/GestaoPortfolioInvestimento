using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Domain.Entities
{
    public class ProdutoFinanceiro
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Preco do produto
        /// </summary>
        public decimal Preco { get; set; }

        /// <summary>
        /// DataVencimento do produto
        /// </summary>
        public DateTime DataVencimento { get; set; }
    }
}
