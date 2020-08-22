using ecommerce.Models;
using ecommerce.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Application
{
    public class CartsActions : ControllerBase
    {
        private readonly ContextDb _context;
        public CartsActions(ContextDb context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Cart>>> Get()
        {
            return await _context.Cart.ToListAsync();
        }

        public async Task<ActionResult<Cart>> GetById(int id)
        {
            var cart = await _context.Cart.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        public async Task<IActionResult> Put(int id, Cart cart)
        {
            if (id != cart.IdCart)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

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

        public async Task<ActionResult<Cart>> Post(Cart cart)
        {
            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.IdCart }, cart);
        }

        public async Task<ActionResult<Cart>> Delete(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return cart;
        }

        private bool Exists(int id)
        {
            return _context.Cart.Any(e => e.IdCart == id);
        }
    }
}
