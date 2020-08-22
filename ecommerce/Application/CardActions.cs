using ecommerce.Models;
using ecommerce.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Application
{
    public class CardActions : ControllerBase
    {
        private readonly ContextDb _context;
        public CardActions(ContextDb context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Card>>> Get()
        {
            return await _context.Card.ToListAsync();
        }

        public async Task<ActionResult<Card>> GetById(int id)
        {
            var card = await _context.Card.FindAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return card;
        }

        public async Task<IActionResult> Put(int id, Card card)
        {
            if (id != card.IdCard)
            {
                return BadRequest();
            }

            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
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

        public async Task<ActionResult<Card>> Post(Card card)
        {
            _context.Card.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCard", new { id = card.IdCard }, card);
        }

        public async Task<ActionResult<Card>> Delete(int id)
        {
            var card = await _context.Card.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            _context.Card.Remove(card);
            await _context.SaveChangesAsync();

            return card;
        }

        private bool Exists(int id)
        {
            return _context.Card.Any(e => e.IdCard == id);
        }
    }
}
