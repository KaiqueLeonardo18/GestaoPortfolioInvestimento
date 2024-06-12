using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Application.Interfaces
{
    public interface IClienteInvestimentosService
    {
        Task<ClienteInvestimento> Create(ClienteInvestimentoDto dto);
        Task<bool> VenderProduto(ClienteInvestimentoDto dto);
        Task<IEnumerable<TransacaoInvestimento>> ExtratoList(int userId);
        Task<IEnumerable<ClienteInvestimento>> ListProdutoCliente(int userId);
    }
}
