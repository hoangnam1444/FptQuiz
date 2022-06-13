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
    public class MajorResultsController : ControllerBase
    {
        private readonly MajorResultContext _context;

        public MajorResultsController(MajorResultContext context)
        {
            _context = context;
        }

        // GET: api/MajorResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MajorResult>>> GetMajorResult()
        {
          if (_context.MajorResult == null)
          {
              return NotFound();
          }
            return await _context.MajorResult.ToListAsync();
        }

        // GET: api/MajorResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MajorResult>> GetMajorResult(string id)
        {
          if (_context.MajorResult == null)
          {
              return NotFound();
          }
            var majorResult = await _context.MajorResult.FindAsync(id);

            if (majorResult == null)
            {
                return NotFound();
            }

            return majorResult;
        }

        // PUT: api/MajorResults/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMajorResult(string id, MajorResult majorResult)
        {
            if (id != majorResult.MResultID)
            {
                return BadRequest();
            }

            _context.Entry(majorResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MajorResultExists(id))
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

        // POST: api/MajorResults
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MajorResult>> PostMajorResult(MajorResult majorResult)
        {
          if (_context.MajorResult == null)
          {
              return Problem("Entity set 'MajorResultContext.MajorResult'  is null.");
          }
            _context.MajorResult.Add(majorResult);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MajorResultExists(majorResult.MResultID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMajorResult", new { id = majorResult.MResultID }, majorResult);
        }

        // DELETE: api/MajorResults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMajorResult(string id)
        {
            if (_context.MajorResult == null)
            {
                return NotFound();
            }
            var majorResult = await _context.MajorResult.FindAsync(id);
            if (majorResult == null)
            {
                return NotFound();
            }

            _context.MajorResult.Remove(majorResult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MajorResultExists(string id)
        {
            return (_context.MajorResult?.Any(e => e.MResultID == id)).GetValueOrDefault();
        }
    }
}
