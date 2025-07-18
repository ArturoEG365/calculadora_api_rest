using Microsoft.EntityFrameworkCore;
using WSArtemisaApi.Data;
using WSArtemisaApi.Models;
using WSArtemisaApi.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSArtemisaApi.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.CardBrand)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Email = u.Email,
                    Name = u.Name,
                    LastName = u.LastName,
                    CardBrandName = u.CardBrand.BrandName
                })
                .ToListAsync();
        }
    }
}
