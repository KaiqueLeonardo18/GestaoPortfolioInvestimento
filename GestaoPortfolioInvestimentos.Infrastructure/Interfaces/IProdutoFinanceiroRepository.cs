using GestaoPortfolioInvestimentos.Domain.Entities;
using GestaoPortfolioInvestimentos.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Infrastructure.Interfaces
{
    public interface IProdutoFinanceiroRepository : IRepository<ProdutoFinanceiro>
    {
        Task<IList<ProdutoFinanceiro>> GetList();
        Task<IEnumerable<ProdutoFinanceiro>> GetServicosAVencer();
    }
}
