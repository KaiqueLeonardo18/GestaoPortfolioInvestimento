using GestaoPortfolioInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Infrastructure.Interfaces
{
    public interface IClienteInvestimentosRepository : IRepository<ClienteInvestimento>
    {
        Task<ClienteInvestimento> GetById(int id);
        Task Remove(ClienteInvestimento clienteInvestimento);
    }
}
