using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Application.Interfaces;
using GestaoPortfolioInvestimentos.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPortfolioInvestimentos.Presentation.API.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoInvestimento : ControllerBase
    {
        private readonly IProdutoFinanceiroService _produtoFinanceiroService;

        public ProdutoInvestimento(IProdutoFinanceiroService produtoFinanceiroService)
        {
            _produtoFinanceiroService = produtoFinanceiroService;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Create(ProdutoFinanceiroDto dto)
        {
            if(dto == null)
                return NotFound();

            var produto =  await _produtoFinanceiroService.Create(dto);
           return CreatedAtAction(nameof(Create), new { Nome = produto.Nome, produto.Preco }, produto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProdutoFinanceiroDto dto)
        {
            if (dto == null)
                return NotFound();

            _produtoFinanceiroService.Update(id, dto);
            return NoContent();
        }

        [HttpGet("listarProdutos")]
        public async Task<IList<ProdutoFinanceiro>> GetList()
        {
            return await _produtoFinanceiroService.List();
        }
    }
}
