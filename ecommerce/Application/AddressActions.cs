using ecommerce.Models;
using ecommerce.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Application
{
    public class AddressActions : ControllerBase
    {
        private readonly ContextDb _context;
        public AddressActions(ContextDb context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Address>>> Get()
        {
            return await _context.Address.ToListAsync();
        }

        public async Task<ActionResult<Address>> GetById(int id)
        {
            var address = await _context.Address.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        public async Task<IActionResult> Put(int id, Address address)
        {
            if (id != address.IdAddress)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

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

        public async Task<ActionResult<Address>> Post(Address address)
        {
            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.IdAddress }, address);
        }

        public async Task<ActionResult<Address>> Delete(int id)
        {
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }

        private bool Exists(int id)
        {
            return _context.Address.Any(e => e.IdAddress == id);
        }
    }
}
