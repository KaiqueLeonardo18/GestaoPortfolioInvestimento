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
        /// Nome
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Preco
        /// </summary>
        public decimal Preco { get; set; }
    }
}
