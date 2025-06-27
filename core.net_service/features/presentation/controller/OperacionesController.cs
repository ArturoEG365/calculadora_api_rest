using Domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTO;
using Domain.Models;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        private readonly CreateOperacionUseCase _createOperacionUseCase;
        private readonly ILogger<OperacionesController> _logger;

        // Inyectamos el logger en el constructor
        public OperacionesController(CreateOperacionUseCase createOperacionUseCase, ILogger<OperacionesController> logger)
        {
            _createOperacionUseCase = createOperacionUseCase;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOperacion([FromBody] OperacionInputDto operacionInput)
        {
            _logger.LogInformation("Inicio de la creación de operación: Tipo: {Tipo}, Numero1: {Numero1}, Numero2: {Numero2}",
                                    operacionInput.Tipo, operacionInput.Numero1, operacionInput.Numero2);

            try
            {
                var operacion = await _createOperacionUseCase.ExecuteAsync(operacionInput);

                _logger.LogInformation("Operación creada exitosamente con ID: {OperacionId}", operacion.Id);

                return CreatedAtAction(nameof(CreateOperacion), new { id = operacion.Id }, operacion);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning("Error en la operación (InvalidOperationException): {Message}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Error en la operación (ArgumentException): {Message}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inesperado: {Message}", ex.Message);
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }
    }
}
