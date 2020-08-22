using ecommerce.Models;
using ecommerce.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Application
{
    public class PurchaseActions : ControllerBase
    {
        private readonly ContextDb _context;
        public PurchaseActions(ContextDb context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Purchase>>> Get()
        {
            return await _context.Purchase.ToListAsync();
        }

        public async Task<ActionResult<Purchase>> GetByid(int id)
        {
            var purchase = await _context.Purchase.FindAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }

            return purchase;
        }

        public async Task<IActionResult> Put(int id, Purchase purchase)
        {
            if (id != purchase.IdPurchase)
            {
                return BadRequest();
            }

            _context.Entry(purchase).State = EntityState.Modified;

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

        public async Task<ActionResult<Purchase>> Post(Purchase purchase)
        {
            _context.Purchase.Add(purchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchase", new { id = purchase.IdPurchase }, purchase);
        }

        public async Task<ActionResult<Purchase>> Delete(int id)
        {
            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();

            return purchase;
        }

        private bool Exists(int id)
        {
            return _context.Purchase.Any(e => e.IdPurchase == id);
        }
    }
}
