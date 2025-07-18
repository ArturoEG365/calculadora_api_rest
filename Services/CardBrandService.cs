using WSArtemisaApi.Data;
using WSArtemisaApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WSArtemisaApi.Services
{
    public class CardBrandService
    {
        private readonly ApplicationDbContext _context;

        public CardBrandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CardBrand>> GetAllCardBrandsAsync()
        {
            return await _context.CardBrands.ToListAsync();
        }

        public async Task<CardBrand> CreateCardBrandAsync(string brandName)
        {
            var cardBrand = new CardBrand
            {
                Id = Guid.NewGuid(),
                BrandName = brandName,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.CardBrands.Add(cardBrand);
            await _context.SaveChangesAsync();

            return cardBrand;
        }

        public async Task<bool> DeleteCardBrandAsync(Guid id)
        {
            var cardBrand = await _context.CardBrands.FindAsync(id);
            if (cardBrand == null)
                return false;

            _context.CardBrands.Remove(cardBrand);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CardBrand> UpdateCardBrandAsync(Guid id, string brandName)
        {
            var cardBrand = await _context.CardBrands.FindAsync(id);
            if (cardBrand == null)
                return null;

            cardBrand.BrandName = brandName;
            cardBrand.UpdatedAt = DateTime.UtcNow;

            _context.CardBrands.Update(cardBrand);
            await _context.SaveChangesAsync();

            return cardBrand;
        }
    }
}
