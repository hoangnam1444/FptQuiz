using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FptQuiz.Data;
using FptQuiz.Model;

namespace FptQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnisController : ControllerBase
    {
        private readonly UniContext _context;

        public UnisController(UniContext context)
        {
            _context = context;
        }

        // GET: api/Unis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uni>>> GetUni()
        {
          if (_context.Uni == null)
          {
              return NotFound();
          }
            return await _context.Uni.ToListAsync();
        }

        // GET: api/Unis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uni>> GetUni(string id)
        {
          if (_context.Uni == null)
          {
              return NotFound();
          }
            var uni = await _context.Uni.FindAsync(id);

            if (uni == null)
            {
                return NotFound();
            }

            return uni;
        }

        // PUT: api/Unis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUni(string id, Uni uni)
        {
            if (id != uni.UniID)
            {
                return BadRequest();
            }

            _context.Entry(uni).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Unis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Uni>> PostUni(Uni uni)
        {
          if (_context.Uni == null)
          {
              return Problem("Entity set 'UniContext.Uni'  is null.");
          }
            _context.Uni.Add(uni);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UniExists(uni.UniID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUni", new { id = uni.UniID }, uni);
        }

        // DELETE: api/Unis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUni(string id)
        {
            if (_context.Uni == null)
            {
                return NotFound();
            }
            var uni = await _context.Uni.FindAsync(id);
            if (uni == null)
            {
                return NotFound();
            }

            _context.Uni.Remove(uni);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UniExists(string id)
        {
            return (_context.Uni?.Any(e => e.UniID == id)).GetValueOrDefault();
        }
    }
}
