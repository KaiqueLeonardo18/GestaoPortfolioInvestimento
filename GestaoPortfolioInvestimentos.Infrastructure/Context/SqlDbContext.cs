using GestaoPortfolioInvestimentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Infrastructure.Context
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

        public DbSet<ProdutoFinanceiro> produtoFinanceiro { get; set; }
        public DbSet<TransacaoInvestimento> transacaoInvestimentos { get; set; }
        public DbSet<ClienteInvestimento> clienteInvestimentos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
