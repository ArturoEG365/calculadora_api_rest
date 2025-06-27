using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IOperacionRepository
    {
        Task AddOperacionAsync(Operacion operacion);
    }
}
