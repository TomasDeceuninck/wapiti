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
    public class DeckBoardsController : ControllerBase
    {
        private readonly WapitiDbContext _context;

        public DeckBoardsController(WapitiDbContext context)
        {
            _context = context;
        }

        // GET: api/DeckBoards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeckBoard>>> GetDeckBoards()
        {
            return await _context.DeckBoards.ToListAsync();
        }

        // GET: api/DeckBoards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeckBoard>> GetDeckBoard(Guid id)
        {
            var deckBoard = await _context.DeckBoards.FindAsync(id);

            if (deckBoard == null)
            {
                return NotFound();
            }

            return deckBoard;
        }

        // PUT: api/DeckBoards/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeckBoard(Guid id, DeckBoard deckBoard)
        {
            if (id != deckBoard.Id)
            {
                return BadRequest();
            }

            _context.Entry(deckBoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeckBoardExists(id))
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

        // POST: api/DeckBoards
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DeckBoard>> PostDeckBoard(DeckBoard deckBoard)
        {
            _context.DeckBoards.Add(deckBoard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeckBoard", new { id = deckBoard.Id }, deckBoard);
        }

        // DELETE: api/DeckBoards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeckBoard>> DeleteDeckBoard(Guid id)
        {
            var deckBoard = await _context.DeckBoards.FindAsync(id);
            if (deckBoard == null)
            {
                return NotFound();
            }

            _context.DeckBoards.Remove(deckBoard);
            await _context.SaveChangesAsync();

            return deckBoard;
        }

        private bool DeckBoardExists(Guid id)
        {
            return _context.DeckBoards.Any(e => e.Id == id);
        }
    }
}
