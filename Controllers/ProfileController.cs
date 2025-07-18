using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using WSArtemisaApi.Services;
using WSArtemisaApi.Models;
using WSArtemisaApi.DTOs;

namespace WSArtemisaApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _profileService;

        public ProfileController(ProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized("Usuario no autenticado.");
            }

            var user = await _profileService.GetProfileAsync(Guid.Parse(userId));
            if (user == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            return Ok(new
            {
                user.Email,
                user.Name,
                user.LastName,
                user.CardBrandId,
                user.Wallet,
                user.CreatedAt,
                user.UpdatedAt
            });
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileUpdateDTO model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized("Usuario no autenticado.");
            }

            var user = await _profileService.UpdateProfileAsync(Guid.Parse(userId), model.Name, model.LastName, model.CardBrandId, model.Wallet);
            return Ok(new { message = "Perfil actualizado correctamente." });
        }
    }


}
