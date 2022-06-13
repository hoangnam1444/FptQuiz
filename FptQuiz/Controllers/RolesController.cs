using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FptQuiz.Data;
using FptQuiz.Model;
using Microsoft.AspNetCore.Authorization;

namespace FptQuiz.Controllers
{   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RolesContext _context;


        public RolesController(RolesContext context)
        {
            _context = context;
            
        }


        

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRole()
        {
          if (_context.Role == null)
          {
                
                return NotFound();
          }
 
            return await _context.Role.ToListAsync();
        }
     

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(string id)
        {
          if (_context.Role == null)
          {
              return NotFound();
          }
            var role = await _context.Role.FindAsync(id);
           

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(string id, Role role)
        {
            if (id != role.RoleID)
            {
                return BadRequest();
            }
            
            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
          if (_context.Role == null)
          {
              return Problem("Entity set 'RolesContext.Role'  is null.");
          }
            _context.Role.Add(role);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoleExists(role.RoleID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRole", new { id = role.RoleID }, role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (_context.Role == null)
            {
                return NotFound();
            }
            var role = await _context.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Role.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(string id)
        {
            return (_context.Role?.Any(e => e.RoleID == id)).GetValueOrDefault();
        }

        private async Task Addrole()
        {

            var role1 = new Role();
            role1.RoleID = "3";
            role1.RoleName = "aaa";

                await PostRole(role1);
            

        }

        /*
        [HttpGet("getAllAdmin")]
        public async Task<ActionResult<IEnumerable<Role>>> GetRole2()
        {
            if (_context.Role == null)
            {
                return null;
               
            }
#pragma warning disable CS8604 // Possible null reference argument.
               List<Role> RoleAdmin = new List<Role> {
                   _context.Role.Where(e => e.RoleName == "Admin").ToList(),
               };
   #pragma warning restore CS8604 // Possible null reference argument.
           
            return _context.Role.Where(e => e.RoleName == "Admin").ToList();
        }
      
        */
    }
}
