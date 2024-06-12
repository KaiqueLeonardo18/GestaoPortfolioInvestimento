using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Application.Interfaces
{
    public interface IProdutoFinanceiroService
    {
        Task<ProdutoFinanceiro> Create(ProdutoFinanceiroDto dto);
        Task<ProdutoFinanceiro> GetById(int id);
        Task<IList<ProdutoFinanceiro>> List();
        ProdutoFinanceiro Update(int id, ProdutoFinanceiroDto dto);
        Task<IEnumerable<ProdutoFinanceiro>> ProdutosAVencer();
    }
}
