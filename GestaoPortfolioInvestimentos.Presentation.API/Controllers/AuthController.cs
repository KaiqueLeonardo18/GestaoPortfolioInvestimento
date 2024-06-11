using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPortfolioInvestimentos.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IPasswordHasher _passwordHasher;
        const string USUARIO_NAO_ENCONTRADO = "Usuário não encontrado";
        const string USUARIO_OU_SENHA_INCORRETA = "Usuário ou senha incorreta!";
        public AuthController(IAuthService authService, IPasswordHasher passwordHasher)
        {
            _authService = authService;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Register([FromBody] RegisterUser dto)
        {
            var user = await _authService.RegisterAsync(dto);

            return CreatedAtAction(nameof(Register), new { name = user.Username }, user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateRequest dto)
        {
            var user = await _authService.LoginAsync(dto);
            if (user == null)
            {
                return NotFound(new { Message = USUARIO_NAO_ENCONTRADO });
            }

            if (!_passwordHasher.VerificarPassword(dto.Password, user.Password))
            {
                return BadRequest(USUARIO_OU_SENHA_INCORRETA);
            }

            var token = await _authService.GenerateToken(user);
            var result = new AuthenticateResponse(user, token);

            return Ok(result);
        }
    }
}