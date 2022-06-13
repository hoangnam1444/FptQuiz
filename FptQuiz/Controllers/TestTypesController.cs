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
    public class TestTypesController : ControllerBase
    {
        private readonly TestTypeContext _context;

        public TestTypesController(TestTypeContext context)
        {
            _context = context;
        }

        // GET: api/TestTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestType>>> GetTestType()
        {
          if (_context.TestType == null)
          {
              return NotFound();
          }
            return await _context.TestType.ToListAsync();
        }

        // GET: api/TestTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestType>> GetTestType(string id)
        {
          if (_context.TestType == null)
          {
              return NotFound();
          }
            var testType = await _context.TestType.FindAsync(id);

            if (testType == null)
            {
                return NotFound();
            }

            return testType;
        }

        // PUT: api/TestTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestType(string id, TestType testType)
        {
            if (id != testType.TestTypeID)
            {
                return BadRequest();
            }

            _context.Entry(testType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestTypeExists(id))
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

        // POST: api/TestTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestType>> PostTestType(TestType testType)
        {
          if (_context.TestType == null)
          {
              return Problem("Entity set 'TestTypeContext.TestType'  is null.");
          }
            _context.TestType.Add(testType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TestTypeExists(testType.TestTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTestType", new { id = testType.TestTypeID }, testType);
        }

        // DELETE: api/TestTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestType(string id)
        {
            if (_context.TestType == null)
            {
                return NotFound();
            }
            var testType = await _context.TestType.FindAsync(id);
            if (testType == null)
            {
                return NotFound();
            }

            _context.TestType.Remove(testType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestTypeExists(string id)
        {
            return (_context.TestType?.Any(e => e.TestTypeID == id)).GetValueOrDefault();
        }
    }
}
