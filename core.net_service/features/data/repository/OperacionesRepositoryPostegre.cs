using Data.DTO;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class OperacionRepository : IOperacionRepository
    {
        private readonly OperacionesEntity _context;

        public OperacionRepository(OperacionesEntity context)
        {
            _context = context;
        }
        public async Task AddOperacionAsync(Operacion operacion)
        {
            await _context.Operaciones.AddAsync(operacion);
            await _context.SaveChangesAsync();
        }
    }
}
