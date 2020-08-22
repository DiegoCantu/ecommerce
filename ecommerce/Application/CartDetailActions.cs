using ecommerce.Models;
using ecommerce.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Application
{
    public class CartDetailActions: ControllerBase
    {
        private readonly ContextDb _context;
        public CartDetailActions(ContextDb context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<CartDetail>>> Get()
        {
            return await _context.CartDetail.ToListAsync();
        }

        public async Task<ActionResult<CartDetail>> GetById(int id)
        {
            var cartDetail = await _context.CartDetail.FindAsync(id);

            if (cartDetail == null)
            {
                return NotFound();
            }

            return cartDetail;
        }

        public async Task<IActionResult> Put(int id, CartDetail cartDetail)
        {
            if (id != cartDetail.IdCartDetail)
            {
                return BadRequest();
            }

            _context.Entry(cartDetail).State = EntityState.Modified;

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

        public async Task<ActionResult<CartDetail>> Post(CartDetail cartDetail)
        {
            _context.CartDetail.Add(cartDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartDetail", new { id = cartDetail.IdCartDetail }, cartDetail);
        }

        public async Task<ActionResult<CartDetail>> Delete(int id)
        {
            var cartDetail = await _context.CartDetail.FindAsync(id);
            if (cartDetail == null)
            {
                return NotFound();
            }

            _context.CartDetail.Remove(cartDetail);
            await _context.SaveChangesAsync();

            return cartDetail;
        }

        private bool Exists(int id)
        {
            return _context.CartDetail.Any(e => e.IdCartDetail == id);
        }
    }
}
