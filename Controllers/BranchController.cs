using Microsoft.AspNetCore.Mvc;
using WSArtemisaApi.Data;
using WSArtemisaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WSArtemisaApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BranchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetBranches()
        {
            return await _context.Branches.OrderByDescending(b => b.CreatedAt).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Branch>> CreateBranch([FromBody] Branch branch)
        {
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBranches), new { id = branch.Id }, branch);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBranch(Guid id, [FromBody] Branch branch)
        {
            if (id != branch.Id)
            {
                return BadRequest();
            }

            _context.Entry(branch).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBranch(Guid id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
