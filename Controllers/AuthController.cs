using Microsoft.AspNetCore.Mvc;
using WSArtemisaApi.DTOs;
using WSArtemisaApi.Services;
using WSArtemisaApi.Models;

namespace WSArtemisaApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthRequestDTO dto)
        {
            var user = new User
            {
                Email = dto.Email,
                Name = dto.Name,
                LastName = dto.LastName,
                CardBrandId = dto.CardBrandId,
                Wallet = dto.Wallet
            };

            var token = await _authService.RegisterAsync(user, dto.Password);
            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO dto)
        {
            var token = await _authService.LoginAsync(dto.Email, dto.Password);
            return Ok(new { Token = token });
        }
    }
}
