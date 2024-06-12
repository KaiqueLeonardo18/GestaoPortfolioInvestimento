using GestaoPortfolioInvestimentos.Domain.Entities;
using GestaoPortfolioInvestimentos.Infrastructure.Context;
using GestaoPortfolioInvestimentos.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Infrastructure.Repositories
{
    public class TransacaoInvestimentosRepository : Repository<TransacaoInvestimento>, ITransacaoInvestimentosRepository
    {
        private readonly SqlDbContext _db;
        public TransacaoInvestimentosRepository(SqlDbContext sqlDbContext) : base(sqlDbContext)
        {
            _db = sqlDbContext;
        }

        public async Task<IEnumerable<TransacaoInvestimento>> ExtratoList(int userId)
        {
            return await _db.transacaoInvestimentos.Include(x => x.ProdutoFinanceiro).Include(x => x.User).ToListAsync();
        }
    }
}
