using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WSArtemisaApi.Data;
using WSArtemisaApi.Models;

namespace WSArtemisaApi.Services
{
    public class TransactionService
    {
        private readonly ApplicationDbContext _context;

        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> CreateTransactionAsync(Guid fromUserId, Guid toUserId, decimal amount, string operationType, string status)
        {
            var fromUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == fromUserId);
            var toUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == toUserId);

            if (fromUser == null || toUser == null)
                throw new Exception("Usuarios no encontrados.");

            // Verificar si el usuario tiene suficiente saldo
            if (fromUser.Wallet < amount)
                throw new Exception("Saldo insuficiente para realizar la transacción.");

            // Crear la transacción
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                FromUserId = fromUserId,
                ToUserId = toUserId,
                Amount = amount,
                Status = status,
                TransactionTime = DateTime.UtcNow,
                FromCardBrandId = fromUser.CardBrandId,
                ToCardBrandId = toUser.CardBrandId
            };

            fromUser.Wallet -= amount;

            toUser.Wallet += amount;

            _context.Transactions.Add(transaction);
            _context.Users.Update(fromUser);
            _context.Users.Update(toUser);

            await _context.SaveChangesAsync();

            return transaction;
        }

        public async Task<IQueryable<Transaction>> GetRecentTransactionsAsync()
        {
            return _context.Transactions.OrderByDescending(t => t.TransactionTime).Take(10);
        }

        public async Task<IQueryable<Transaction>> GetTransactionsByUserAsync(Guid userId)
        {
            return _context.Transactions
                .Where(t => t.FromUserId == userId || t.ToUserId == userId)
                .OrderByDescending(t => t.TransactionTime);
        }
    }
}
