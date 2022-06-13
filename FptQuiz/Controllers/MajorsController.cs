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
    public class MajorsController : ControllerBase
    {
        private readonly MajorContext _context;

        public MajorsController(MajorContext context)
        {
            _context = context;
        }

        // GET: api/Majors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Major>>> GetMajor()
        {
          if (_context.Major == null)
          {
              return NotFound();
          }
            return await _context.Major.ToListAsync();
        }

        // GET: api/Majors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Major>> GetMajor(string id)
        {
          if (_context.Major == null)
          {
              return NotFound();
          }
            var major = await _context.Major.FindAsync(id);

            if (major == null)
            {
                return NotFound();
            }

            return major;
        }

        // PUT: api/Majors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMajor(string id, Major major)
        {
            if (id != major.MajorID)
            {
                return BadRequest();
            }

            _context.Entry(major).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MajorExists(id))
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

        // POST: api/Majors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Major>> PostMajor(Major major)
        {
          if (_context.Major == null)
          {
              return Problem("Entity set 'MajorContext.Major'  is null.");
          }
            _context.Major.Add(major);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MajorExists(major.MajorID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMajor", new { id = major.MajorID }, major);
        }

        // DELETE: api/Majors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMajor(string id)
        {
            if (_context.Major == null)
            {
                return NotFound();
            }
            var major = await _context.Major.FindAsync(id);
            if (major == null)
            {
                return NotFound();
            }

            _context.Major.Remove(major);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MajorExists(string id)
        {
            return (_context.Major?.Any(e => e.MajorID == id)).GetValueOrDefault();
        }
    }
}
