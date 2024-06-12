using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Application.Interfaces;
using GestaoPortfolioInvestimentos.Domain.Entities;
using GestaoPortfolioInvestimentos.Domain.Enums;
using GestaoPortfolioInvestimentos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Application.Services
{
    public class ClienteInvestimentosService : IClienteInvestimentosService
    {
        private readonly ITransacaoInvestimentoService _transacaoInvestimentoService;
        private readonly IClienteInvestimentosRepository _clienteInvestimentosRepository;

        public ClienteInvestimentosService(IClienteInvestimentosRepository clienteInvestimentosRepository, ITransacaoInvestimentoService transacaoInvestimento)
        {
            _clienteInvestimentosRepository = clienteInvestimentosRepository;
            _transacaoInvestimentoService = transacaoInvestimento;
        }

        public async Task<ClienteInvestimento> Create(ClienteInvestimentoDto dto)
        {
            var clienteInvestimento = new ClienteInvestimento
            {
                ProdutoFinanceiroId = dto.ProdutoFinanceiroId,
                UserId = dto.UserId,
                Quantidade = dto.Quantidade,
            };
            await _clienteInvestimentosRepository.CreateAsync(clienteInvestimento);
            clienteInvestimento = await GetById(clienteInvestimento.Id);
            await _transacaoInvestimentoService.RegistrarTransacao(
                  _transacaoInvestimentoService.MontarDtoTransacaoInvestimento(
                                                clienteInvestimento.ProdutoFinanceiroId, clienteInvestimento.Quantidade,
                                                TipoTransacao.Compra, clienteInvestimento.UserId));
            return clienteInvestimento;
        }

        public async Task<bool> VenderProduto(ClienteInvestimentoDto dto)
        {
            var clienteInvestimento = await _clienteInvestimentosRepository.GetAsync(x => x.ProdutoFinanceiroId == dto.ProdutoFinanceiroId);

            if ((clienteInvestimento.Quantidade - dto.Quantidade) <= 0)
            {
                await _clienteInvestimentosRepository.Remove(clienteInvestimento);
                await _transacaoInvestimentoService.RegistrarTransacao(
                      _transacaoInvestimentoService.MontarDtoTransacaoInvestimento(
                                                clienteInvestimento.ProdutoFinanceiroId, clienteInvestimento.Quantidade,
                                                TipoTransacao.Venda, clienteInvestimento.UserId));
                return true;
            }
            else
            {
                clienteInvestimento.Quantidade -= dto.Quantidade;
                await _transacaoInvestimentoService.RegistrarTransacao(
                      _transacaoInvestimentoService.MontarDtoTransacaoInvestimento(
                                      clienteInvestimento.ProdutoFinanceiroId, clienteInvestimento.Quantidade,
                                      TipoTransacao.Venda, clienteInvestimento.UserId));
                _clienteInvestimentosRepository.Update(clienteInvestimento);
                return true;
            }
        }

        public async Task<ClienteInvestimento> GetById(int id)
        {
            return await _clienteInvestimentosRepository.GetById(id);
        }

        public async Task<IEnumerable<ClienteInvestimento>> ListProdutoCliente(int userId)
        {
            return await _clienteInvestimentosRepository.ListProdutoCliente(userId);
        }

        public async Task<IEnumerable<TransacaoInvestimento>> ExtratoList(int userId)
        {
            return await _transacaoInvestimentoService.ExtratoList(userId);
        }
    }
}
