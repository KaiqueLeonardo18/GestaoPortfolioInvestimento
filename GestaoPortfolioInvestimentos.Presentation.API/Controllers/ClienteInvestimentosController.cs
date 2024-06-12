using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Application.Interfaces;
using GestaoPortfolioInvestimentos.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace GestaoPortfolioInvestimentos.Presentation.API.Controllers
{
    [Authorize(Roles = "client")]
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteInvestimentosController : ControllerBase
    {
        private readonly ITransacaoInvestimentoService _transacaoInvestimentoService;
        private readonly IClienteInvestimentosService _clienteInvestimentosService;
        public ClienteInvestimentosController(ITransacaoInvestimentoService transacaoInvestimentoService, IClienteInvestimentosService clienteInvestimentosService)
        {
            _transacaoInvestimentoService = transacaoInvestimentoService;
            _clienteInvestimentosService = clienteInvestimentosService;
        }

        /// <summary>
        /// Endpoint para comprar um Produto de Investimento
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("comprar")]
        public async Task<IActionResult> ComprarInvestimento([FromBody] ClienteInvestimentoDto dto)
        {
            try
            {
                dto.UserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
                var transacaoInvestimento = await _clienteInvestimentosService.Create(dto);

                return CreatedAtAction(nameof(ComprarInvestimento),
                                       new
                                       {
                                           Produto = transacaoInvestimento.ProdutoFinanceiro,
                                           transacaoInvestimento.DataTransacao,
                                           transacaoInvestimento.Quantidade
                                       }, transacaoInvestimento);
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
        /// Endpoint para Vender um Produto de Investimento
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("vender")]
        public async Task<IActionResult> VenderInvestimento(ClienteInvestimentoDto dto)
        {
            try
            {
                dto.UserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
                var transacaoInvestimento = await _clienteInvestimentosService.VenderProduto(dto);

                return Ok("Produto vendido com sucesso!");
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
        /// Endpoint para gerar um Extrato das Transações do cliente logado.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ExtratoTransacoes()
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
                return Ok(await _transacaoInvestimentoService.ExtratoList(userId));
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
