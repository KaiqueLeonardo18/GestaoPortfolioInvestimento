using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace GestaoPortfolioInvestimentos.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/teste/[controller]")]
    public class ClienteInvestimentosController : ControllerBase
    {
        private readonly ITransacaoInvestimentoService _transacaoInvestimentoService;
        private readonly IClienteInvestimentosService _clienteInvestimentosService;
        public ClienteInvestimentosController(ITransacaoInvestimentoService transacaoInvestimentoService, IClienteInvestimentosService clienteInvestimentosService)
        {
            _transacaoInvestimentoService = transacaoInvestimentoService;
            _clienteInvestimentosService = clienteInvestimentosService;
        }

        [HttpPost("comprar")]
        public async Task<IActionResult> ComprarInvestimento(ClienteInvestimentoDto dto)
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
            catch (Exception ex)
            {
                return StatusCode(500, HttpStatusCode.BadGateway);
            }
        }

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
            catch (Exception ex)
            {
                return StatusCode(500, HttpStatusCode.BadGateway);
            }
        }
    }
}
