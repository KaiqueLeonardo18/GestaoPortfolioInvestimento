using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Application.DTOs
{
    public class ProdutoFinanceiroDto
    {
        /// <summary>
        /// Nome do Produto Financeiro
        /// </summary>
        [Required(ErrorMessage = "O campo Username é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Preco do Produto
        /// </summary>
        [Required(ErrorMessage = "O campo Preco é obrigatório.")]
        public decimal Preco { get; set; }

        /// <summary>
        /// DataVencimento do produto
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "O campo DataVencimento é obrigatório.")]
        public DateTime DataVencimento { get; set; }
    }
}
