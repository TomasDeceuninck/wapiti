using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wapiti.Domain.Entities;
using Wapiti.Persistence;

namespace Wapiti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetsController : ControllerBase
    {
        private readonly WapitiDbContext _context;

        public SetsController(WapitiDbContext context)
        {
            _context = context;
        }

        // GET: api/Sets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Set>>> GetSets()
        {
            return await _context.Sets.ToListAsync();
        }

        // GET: api/Sets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Set>> GetSet(string id)
        {
            var @set = await _context.Sets.FindAsync(id);

            if (@set == null)
            {
                return NotFound();
            }

            return @set;
        }

        // PUT: api/Sets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSet(string id, Set @set)
        {
            if (id != @set.Code)
            {
                return BadRequest();
            }

            _context.Entry(@set).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetExists(id))
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

        // POST: api/Sets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Set>> PostSet(Set @set)
        {
            _context.Sets.Add(@set);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SetExists(@set.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSet", new { id = @set.Code }, @set);
        }

        // DELETE: api/Sets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Set>> DeleteSet(string id)
        {
            var @set = await _context.Sets.FindAsync(id);
            if (@set == null)
            {
                return NotFound();
            }

            _context.Sets.Remove(@set);
            await _context.SaveChangesAsync();

            return @set;
        }

        private bool SetExists(string id)
        {
            return _context.Sets.Any(e => e.Code == id);
        }
    }
}
