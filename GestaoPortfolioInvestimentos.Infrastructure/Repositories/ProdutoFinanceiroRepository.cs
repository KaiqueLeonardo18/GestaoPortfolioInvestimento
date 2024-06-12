using GestaoPortfolioInvestimentos.Domain.Entities;
using GestaoPortfolioInvestimentos.Infrastructure.Context;
using GestaoPortfolioInvestimentos.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoPortfolioInvestimentos.Infrastructure.Repositories
{
    public class ProdutoFinanceiroRepository : Repository<ProdutoFinanceiro>, IProdutoFinanceiroRepository
    {
        private readonly SqlDbContext _context;
        private const int PROXIMA_SEMANA = 7;
        public ProdutoFinanceiroRepository(SqlDbContext sqlDbContext) : base(sqlDbContext)
        {
            _context = sqlDbContext;
        }

        public async Task<IList<ProdutoFinanceiro>> GetList()
        {
            return await _context.produtoFinanceiro.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<ProdutoFinanceiro>> GetServicosAVencer()
        {
            var dataPrevia = DateTime.Now.AddDays(PROXIMA_SEMANA);
            return await _context.produtoFinanceiro.AsNoTracking().Where(x => x.DataVencimento >= DateTime.Now 
                                                                         && x.DataVencimento <= dataPrevia).ToListAsync();
        }
    }
}
