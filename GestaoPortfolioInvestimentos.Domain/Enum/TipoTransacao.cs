using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Domain.Enum
{
    public enum TipoTransacao
    {
        /// <summary>
        /// Tipo de Transação de Compra
        /// </summary>
        Compra = 1,
        /// <summary>
        /// Tipo de Transação de Venda
        /// </summary>
        Venda = 2
    }
}
