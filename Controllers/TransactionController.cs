using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WSArtemisaApi.Models;
using WSArtemisaApi.Services;

namespace WSArtemisaApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionRequest model)
        {
            try
            {
                var transaction = await _transactionService.CreateTransactionAsync(model.FromUserId, model.ToUserId, model.Amount, model.OperationType, model.Status);
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentTransactions()
        {
            var transactions = await _transactionService.GetRecentTransactionsAsync();
            return Ok(transactions);
        }

        [HttpGet("history")]
        [Authorize]
        public async Task<IActionResult> GetTransactionHistory()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized("Usuario no autenticado.");
            }

            var transactions = await _transactionService.GetTransactionsByUserAsync(Guid.Parse(userId));
            return Ok(transactions);
        }
    }

    public class TransactionRequest
    {
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public decimal Amount { get; set; }
        public string OperationType { get; set; }
        public string Status { get; set; }
    }
}
