using Microsoft.AspNetCore.Mvc;
using WSArtemisaApi.Services;
using WSArtemisaApi.DTOs;
using WSArtemisaApi.Models;

namespace WSArtemisaApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CardBrandController : ControllerBase
    {
        private readonly CardBrandService _cardBrandService;

        public CardBrandController(CardBrandService cardBrandService)
        {
            _cardBrandService = cardBrandService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCardBrand([FromBody] CreateCardBrandDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.BrandName))
                return BadRequest("El nombre de la marca de tarjeta es obligatorio.");

            var cardBrand = await _cardBrandService.CreateCardBrandAsync(dto.BrandName);
            return CreatedAtAction(nameof(GetAllCardBrands), new { id = cardBrand.Id }, cardBrand);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCardBrands()
        {
            var cardBrands = await _cardBrandService.GetAllCardBrandsAsync();
            return Ok(cardBrands);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardBrand(Guid id)
        {
            var result = await _cardBrandService.DeleteCardBrandAsync(id);
            if (!result)
                return NotFound("Marca de tarjeta no encontrada.");

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCardBrand(Guid id, [FromBody] string brandName)
        {
            if (string.IsNullOrWhiteSpace(brandName))
                return BadRequest("El nombre de la marca de tarjeta es obligatorio.");

            var cardBrand = await _cardBrandService.UpdateCardBrandAsync(id, brandName);
            if (cardBrand == null)
                return NotFound("Marca de tarjeta no encontrada.");

            return Ok(cardBrand);
        }
    }
}
