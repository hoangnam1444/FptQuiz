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
    public class LearningPartsController : ControllerBase
    {
        private readonly LearningPartContext _context;

        public LearningPartsController(LearningPartContext context)
        {
            _context = context;
        }

        // GET: api/LearningParts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LearningPart>>> GetLearningPart()
        {
          if (_context.LearningPart == null)
          {
              return NotFound();
          }
            return await _context.LearningPart.ToListAsync();
        }

        // GET: api/LearningParts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LearningPart>> GetLearningPart(string id)
        {
          if (_context.LearningPart == null)
          {
              return NotFound();
          }
            var learningPart = await _context.LearningPart.FindAsync(id);

            if (learningPart == null)
            {
                return NotFound();
            }

            return learningPart;
        }

        // PUT: api/LearningParts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLearningPart(string id, LearningPart learningPart)
        {
            if (id != learningPart.LearningPartID)
            {
                return BadRequest();
            }

            _context.Entry(learningPart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearningPartExists(id))
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

        // POST: api/LearningParts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LearningPart>> PostLearningPart(LearningPart learningPart)
        {
          if (_context.LearningPart == null)
          {
              return Problem("Entity set 'LearningPartContext.LearningPart'  is null.");
          }
            _context.LearningPart.Add(learningPart);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LearningPartExists(learningPart.LearningPartID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLearningPart", new { id = learningPart.LearningPartID }, learningPart);
        }

        // DELETE: api/LearningParts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLearningPart(string id)
        {
            if (_context.LearningPart == null)
            {
                return NotFound();
            }
            var learningPart = await _context.LearningPart.FindAsync(id);
            if (learningPart == null)
            {
                return NotFound();
            }

            _context.LearningPart.Remove(learningPart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LearningPartExists(string id)
        {
            return (_context.LearningPart?.Any(e => e.LearningPartID == id)).GetValueOrDefault();
        }
    }
}
