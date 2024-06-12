using GestaoPortfolioInvestimentos.Application.DTOs;
using GestaoPortfolioInvestimentos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GestaoPortfolioInvestimentos.Presentation.API.Controllers
{
    /// <summary>
    /// API para manipulações de login e Autorização do usuário
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IPasswordHasher _passwordHasher;
        const string USUARIO_NAO_ENCONTRADO = "Usuário não encontrado";
        const string USUARIO_OU_SENHA_INCORRETA = "Usuário ou senha incorreta!";
        const string USUARIO_COM_ESTE_NOME_JA_EXISTE = "Usuário com este Username já existe";

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="authService"></param>
        /// <param name="passwordHasher"></param>
        public AuthController(IAuthService authService, IPasswordHasher passwordHasher)
        {
            _authService = authService;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Endpoint para Registrar um usuário no sistema
        /// </summary>
        /// <param name="dto"></param>
        /// <example>admin ou client</example>
        /// <returns></returns>
        [HttpPost("registrar")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existsUser = await _authService.ExistsUser(dto.Username, dto.Role);

                if(existsUser)
                {
                    return BadRequest(USUARIO_COM_ESTE_NOME_JA_EXISTE);
                }

                var user = await _authService.RegisterAsync(dto);

                return CreatedAtAction(nameof(Register), new { name = user.Username }, user);
            }
            catch (Exception)
            {
                return StatusCode(500, HttpStatusCode.BadGateway);

            }
        }

        /// <summary>
        /// Endpoint para fazer login no sistema
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateRequest dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

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
            catch (Exception)
            {
                return StatusCode(500, HttpStatusCode.BadGateway);
            }
        }
    }
}