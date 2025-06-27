using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Data.DTO
{
    public class OperacionesEntity : DbContext
    {
        public OperacionesEntity(DbContextOptions<OperacionesEntity> options)
            : base(options) { }
        public DbSet<Operacion> Operaciones { get; set; }
    }
}