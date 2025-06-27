using Data.Repositories;
using Domain.Models;
using Presentation.DTO;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public class CreateOperacionUseCase
    {
        private readonly IOperacionRepository _operacionRepository;

        public CreateOperacionUseCase(IOperacionRepository operacionRepository)
        {
            _operacionRepository = operacionRepository;
        }

        public async Task<Operacion> ExecuteAsync(OperacionInputDto operacionInput)
        {
            var operacion = new Operacion
            {
                Tipo = operacionInput.Tipo,
                Numero1 = operacionInput.Numero1,
                Numero2 = operacionInput.Numero2,
                Resultado = RealizarOperacion(operacionInput),
                FechaOperacion = DateTime.UtcNow
            };

            await _operacionRepository.AddOperacionAsync(operacion);
            return operacion;
        }

        private double RealizarOperacion(OperacionInputDto operacionInput)
        {
            return operacionInput.Tipo switch
            {
                "+" => operacionInput.Numero1 + operacionInput.Numero2,
                "-" => operacionInput.Numero1 - operacionInput.Numero2,
                "*" => operacionInput.Numero1 * operacionInput.Numero2,
                "/" when operacionInput.Numero2 != 0 => operacionInput.Numero1 / operacionInput.Numero2,
                _ => 0,
            };
        }
    }
}
