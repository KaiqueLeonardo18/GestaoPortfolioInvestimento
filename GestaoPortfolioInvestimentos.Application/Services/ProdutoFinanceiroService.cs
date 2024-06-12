using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Application.Interfaces;
using GestaoPortfolioInvestimentos.Domain.Entities;
using GestaoPortfolioInvestimentos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Application.Services
{
    public class ProdutoFinanceiroService : IProdutoFinanceiroService
    {
        private readonly IProdutoFinanceiroRepository _produtoFinanceiroRepository;

        public ProdutoFinanceiroService(IProdutoFinanceiroRepository produtoFinanceiroRepository)
        {
            _produtoFinanceiroRepository = produtoFinanceiroRepository;
        }

        public async Task<IList<ProdutoFinanceiro>> List()
        {
            return await _produtoFinanceiroRepository.GetList();
        }

        public async Task<ProdutoFinanceiro> GetById(int id)
        {
            return await _produtoFinanceiroRepository.GetAsync(x => x.Id == id);
        }

        public async Task<ProdutoFinanceiro> Create(ProdutoFinanceiroDto dto)
        {
            var produto = new ProdutoFinanceiro { Nome = dto.Nome, Preco = dto.Preco , DataVencimento = dto.DataVencimento};
            await _produtoFinanceiroRepository.CreateAsync(produto);
            return produto;
        }

        public async Task<IEnumerable<ProdutoFinanceiro>> ProdutosAVencer()
        {
            return await _produtoFinanceiroRepository.GetServicosAVencer();
        }

        public ProdutoFinanceiro Update(int id, ProdutoFinanceiroDto dto)
        {
            var produto = new ProdutoFinanceiro
            {
                Id = id,
                Nome = dto.Nome,
                Preco = dto.Preco
            };

            _produtoFinanceiroRepository.Update(produto);
            return produto;
        }
    }
}
