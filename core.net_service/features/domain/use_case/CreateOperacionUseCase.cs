using Data.Repositories;
using Domain.Models;
using Presentation.DTO;

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
            if (operacionInput == null)
                throw new ArgumentException("Invalid operation input.");

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
                "/" => throw new InvalidOperationException("Cannot divide by zero."),  // Lanzamos un error si se intenta dividir por cero
                _ => throw new InvalidOperationException("Invalid operation type.")  // Error si el tipo no es reconocido
            };
        }
    }
}
