using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Application.Interfaces;
using GestaoPortfolioInvestimentos.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GestaoPortfolioInvestimentos.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoInvestimento : ControllerBase
    {
        private readonly IProdutoFinanceiroService _produtoFinanceiroService;

        public ProdutoInvestimento(IProdutoFinanceiroService produtoFinanceiroService)
        {
            _produtoFinanceiroService = produtoFinanceiroService;
        }

        /// <summary>
        /// Endpoint para Criar um Produto de Investimento
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Create(ProdutoFinanceiroDto dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                var produto = await _produtoFinanceiroService.Create(dto);
                return CreatedAtAction(nameof(Create), new { Nome = produto.Nome, produto.Preco }, produto);
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(403, HttpStatusCode.Forbidden);
            }
            catch (Exception)
            {
                return StatusCode(500, HttpStatusCode.BadGateway);
            }
        }

        /// <summary>
        /// Endpoint para Atualizar um Produto cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProdutoFinanceiroDto dto)
        {
            try
            {
                if (dto == null)
                    return NotFound();

                _produtoFinanceiroService.Update(id, dto);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(403, HttpStatusCode.Forbidden);
            }
            catch (Exception)
            {
                return StatusCode(500, HttpStatusCode.BadGateway);
            }
        }

        /// <summary>
        /// Endpoint para Listar os Produtos de Investimento.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("listarProdutos")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var produtoList = await _produtoFinanceiroService.List();
                return Ok(produtoList);

            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(403, HttpStatusCode.Forbidden);
            }
            catch (Exception)
            {
                return StatusCode(500, HttpStatusCode.BadGateway);
            }
        }
    }
}
