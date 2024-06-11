using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Domain.Entities;
using GestaoPortfolioInvestimentos.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Application.Interfaces
{
    public interface ITransacaoInvestimentoService
    {
        Task<TransacaoInvestimento> RegistrarTransacao(TransacaoInvestimentoDto dto);
        TransacaoInvestimentoDto MontarDtoTransacaoInvestimento(int produtoId, decimal quantidade, TipoTransacao tipoTransacao, int userId);
    }
}
