using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Application.Interfaces;
using GestaoPortfolioInvestimentos.Domain.Entities;
using GestaoPortfolioInvestimentos.Domain.Enums;
using GestaoPortfolioInvestimentos.Infrastructure.Interfaces;
using GestaoPortfolioInvestimentos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoPortfolioInvestimentos.Application.Services
{
    public class TransacaoInvestimentoService : ITransacaoInvestimentoService
    {
        private readonly ITransacaoInvestimentosRepository _transacaoInvestimentosRepository;

        public TransacaoInvestimentoService(ITransacaoInvestimentosRepository transacaoInvestimentosRepository)
        {
            _transacaoInvestimentosRepository = transacaoInvestimentosRepository;
        }

        public async Task<TransacaoInvestimento> RegistrarTransacao(TransacaoInvestimentoDto dto)
        {
            var transacaoInvestimento = new TransacaoInvestimento
            {
                ProdutoFinanceiroId = dto.ProdutoId,
                UserId = dto.UserId,
                Quantidade = dto.Quantidade,
                TipoTransacao = dto.TipoTransacao,
            };
            await _transacaoInvestimentosRepository.CreateAsync(transacaoInvestimento);
            return transacaoInvestimento;
        }

        public TransacaoInvestimentoDto MontarDtoTransacaoInvestimento(int produtoId, decimal quantidade, TipoTransacao tipoTransacao, int userId)
        {
            return new TransacaoInvestimentoDto
            {
                ProdutoId = produtoId,
                Quantidade = quantidade,
                TipoTransacao = tipoTransacao,
                UserId = userId
            };
        }

        public async Task<IEnumerable<TransacaoInvestimento>> ExtratoList(int userId)
        {
            return await _transacaoInvestimentosRepository.ExtratoList(userId);
        }
    }
}
