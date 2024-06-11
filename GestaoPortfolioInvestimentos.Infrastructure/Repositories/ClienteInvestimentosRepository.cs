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
    public class ClienteInvestimentosRepository : Repository<ClienteInvestimento>, IClienteInvestimentosRepository
    {
        private readonly SqlDbContext _db;

        public ClienteInvestimentosRepository(SqlDbContext sqlDbContext) : base(sqlDbContext)
        {
            _db = sqlDbContext;
        }

        public async Task<ClienteInvestimento> GetById(int id)
        {
            return await _db.clienteInvestimentos.Include(x => x.ProdutoFinanceiro).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Remove(ClienteInvestimento clienteInvestimentos)
        {
            _db.Remove(clienteInvestimentos);
            await SaveAsync();
        }
    }
}
