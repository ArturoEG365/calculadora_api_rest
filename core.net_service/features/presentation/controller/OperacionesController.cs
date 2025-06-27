using Domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTO;
using Domain.Models;
using System.Threading.Tasks;

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
        public async Task<Operacion> CreateOperacion([FromBody] OperacionInputDto operacionInput)
        {
            var operacion = await _createOperacionUseCase.ExecuteAsync(operacionInput);
            return operacion;
        }

    }
}
