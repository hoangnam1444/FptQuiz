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
    public class CareersController : ControllerBase
    {
        private readonly CareerContext _context;

        public CareersController(CareerContext context)
        {
            _context = context;
        }

        // GET: api/Careers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Career>>> GetCareer()
        {
          if (_context.Career == null)
          {
              return NotFound();
          }
            return await _context.Career.ToListAsync();
        }

        // GET: api/Careers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Career>> GetCareer(string id)
        {
          if (_context.Career == null)
          {
              return NotFound();
          }
            var career = await _context.Career.FindAsync(id);

            if (career == null)
            {
                return NotFound();
            }

            return career;
        }

        // PUT: api/Careers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareer(string id, Career career)
        {
            if (id != career.CareerID)
            {
                return BadRequest();
            }

            _context.Entry(career).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerExists(id))
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

        // POST: api/Careers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Career>> PostCareer(Career career)
        {
          if (_context.Career == null)
          {
              return Problem("Entity set 'CareerContext.Career'  is null.");
          }
            _context.Career.Add(career);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CareerExists(career.CareerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCareer", new { id = career.CareerID }, career);
        }

        // DELETE: api/Careers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCareer(string id)
        {
            if (_context.Career == null)
            {
                return NotFound();
            }
            var career = await _context.Career.FindAsync(id);
            if (career == null)
            {
                return NotFound();
            }

            _context.Career.Remove(career);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CareerExists(string id)
        {
            return (_context.Career?.Any(e => e.CareerID == id)).GetValueOrDefault();
        }
    }
}
