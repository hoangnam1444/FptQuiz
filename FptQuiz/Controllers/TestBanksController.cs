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
    public class TestBanksController : ControllerBase
    {
        private readonly TestBankContext _context;

        public TestBanksController(TestBankContext context)
        {
            _context = context;
        }

        // GET: api/TestBanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestBank>>> GetTestBank()
        {
          if (_context.TestBank == null)
          {
              return NotFound();
          }
         
            return await _context.TestBank.OrderBy(s => s.TestBankID).ToListAsync();
        }

        // GET: api/TestBanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestBank>> GetTestBank(string id)
        {
          if (_context.TestBank == null)
          {
              return NotFound();
          }
            var testBank = await _context.TestBank.FindAsync(id);

            if (testBank == null)
            {
                return NotFound();
            }

            return testBank;
        }

        // PUT: api/TestBanks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestBank(string id, TestBank testBank)
        {
            if (id != testBank.TestBankID)
            {
                return BadRequest();
            }

            _context.Entry(testBank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestBankExists(id))
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

        // POST: api/TestBanks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestBank>> PostTestBank(TestBank testBank)
        {
          if (_context.TestBank == null)
          {
              return Problem("Entity set 'TestBankContext.TestBank'  is null.");
          }
            _context.TestBank.Add(testBank);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TestBankExists(testBank.TestBankID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTestBank", new { id = testBank.TestBankID }, testBank);
        }

        // DELETE: api/TestBanks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestBank(string id)
        {
            if (_context.TestBank == null)
            {
                return NotFound();
            }
            var testBank = await _context.TestBank.FindAsync(id);
            if (testBank == null)
            {
                return NotFound();
            }

            _context.TestBank.Remove(testBank);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestBankExists(string id)
        {
            return (_context.TestBank?.Any(e => e.TestBankID == id)).GetValueOrDefault();
        }
        [HttpGet("getAllMBTITest")]
        public async Task<ActionResult<IEnumerable<TestBank>>> getALLMBTITest()
        {
            if (_context.TestBank == null)
            {
                return NoContent();

            }
            return _context.TestBank.Where(e => e.HollandTitle == "" || e.HollandTitle == "string").ToList();
        }
        [HttpGet("getAllHollandTest")]
        public async Task<ActionResult<IEnumerable<TestBank>>> getALLHollandTest()
        {
            if (_context.TestBank == null)
            {
                return NoContent();

            }
            return _context.TestBank.Where(e => e.MBTITitle == "" || e.MBTITitle == "string").ToList();
        }
    }
}
