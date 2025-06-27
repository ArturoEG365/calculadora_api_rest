using Domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTO;
using Domain.Models;
using System.Threading.Tasks;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        private readonly CreateOperacionUseCase _createOperacionUseCase;

        public OperacionesController(CreateOperacionUseCase createOperacionUseCase)
        {
            _createOperacionUseCase = createOperacionUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOperacion([FromBody] OperacionInputDto operacionInput)
        {
            try
            {
                var operacion = await _createOperacionUseCase.ExecuteAsync(operacionInput);
                return CreatedAtAction(nameof(CreateOperacion), new { id = operacion.Id }, operacion);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
    }
}
