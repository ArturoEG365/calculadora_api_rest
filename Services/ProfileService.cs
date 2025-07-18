using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WSArtemisaApi.Data;
using WSArtemisaApi.Models;

namespace WSArtemisaApi.Services
{
    public class ProfileService
    {
        private readonly ApplicationDbContext _context;

        public ProfileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetProfileAsync(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }

        public async Task<User> UpdateProfileAsync(Guid userId, string name, string lastName, Guid? cardBrandId, decimal? wallet)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                throw new Exception("Usuario no encontrado.");

            // Actualizamos los campos que se pasen en el DTO
            user.Name = name ?? user.Name;
            user.LastName = lastName ?? user.LastName;
            user.CardBrandId = cardBrandId ?? user.CardBrandId;
            user.Wallet = wallet ?? user.Wallet;
            user.UpdatedAt = DateTime.UtcNow;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
