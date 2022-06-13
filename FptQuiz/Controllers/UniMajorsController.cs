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
    public class UniMajorsController : ControllerBase
    {
        private readonly UniMajorContext _context;

        public UniMajorsController(UniMajorContext context)
        {
            _context = context;
        }

        // GET: api/UniMajors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UniMajor>>> GetUniMajor()
        {
          if (_context.UniMajor == null)
          {
              return NotFound();
          }
            return await _context.UniMajor.ToListAsync();
        }

        // GET: api/UniMajors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UniMajor>> GetUniMajor(string id)
        {
          if (_context.UniMajor == null)
          {
              return NotFound();
          }
            var uniMajor = await _context.UniMajor.FindAsync(id);

            if (uniMajor == null)
            {
                return NotFound();
            }

            return uniMajor;
        }

        // PUT: api/UniMajors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniMajor(string id, UniMajor uniMajor)
        {
            if (id != uniMajor.UniMajorID)
            {
                return BadRequest();
            }

            _context.Entry(uniMajor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniMajorExists(id))
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

        // POST: api/UniMajors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UniMajor>> PostUniMajor(UniMajor uniMajor)
        {
          if (_context.UniMajor == null)
          {
              return Problem("Entity set 'UniMajorContext.UniMajor'  is null.");
          }
            _context.UniMajor.Add(uniMajor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UniMajorExists(uniMajor.UniMajorID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUniMajor", new { id = uniMajor.UniMajorID }, uniMajor);
        }

        // DELETE: api/UniMajors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniMajor(string id)
        {
            if (_context.UniMajor == null)
            {
                return NotFound();
            }
            var uniMajor = await _context.UniMajor.FindAsync(id);
            if (uniMajor == null)
            {
                return NotFound();
            }

            _context.UniMajor.Remove(uniMajor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UniMajorExists(string id)
        {
            return (_context.UniMajor?.Any(e => e.UniMajorID == id)).GetValueOrDefault();
        }
    }
}
