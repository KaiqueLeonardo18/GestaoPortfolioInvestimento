using GestaoPortfolioInvestimentos.Domain.Entities;
using GestaoPortfolioInvestimentos.Infrastructure.Context;
using GestaoPortfolioInvestimentos.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoPortfolioInvestimentos.Infrastructure.Repositories
{
    public class ProdutoFinanceiroRepository : Repository<ProdutoFinanceiro>, IProdutoFinanceiroRepository
    {
        private readonly SqlDbContext _context;

        public ProdutoFinanceiroRepository(SqlDbContext sqlDbContext) : base(sqlDbContext)
        {
            _context = sqlDbContext;
        }

        public async Task<IList<ProdutoFinanceiro>> GetList()
        {
            return await _context.produtoFinanceiro.AsNoTracking().ToListAsync();
        }
    }
}
