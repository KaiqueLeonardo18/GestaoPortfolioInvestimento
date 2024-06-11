using GestaoPortfolioInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Infrastructure.Interfaces
{
    public interface ITransacaoInvestimentosRepository : IRepository<TransacaoInvestimento>
    {
    }
}
