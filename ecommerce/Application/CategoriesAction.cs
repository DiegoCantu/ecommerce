using ecommerce.Models;
using ecommerce.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Application
{
    public class CategoriesAction : ControllerBase
    {
        private readonly ContextDb _context;
        public CategoriesAction(ContextDb context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<ActionResult<Category>> GetById(int id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        public async Task<IActionResult> Put(int id, Category category)
        {
            if (id != category.IdCategory)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

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

        public async Task<ActionResult<Category>> Post(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.IdCategory }, category);
        }

        public async Task<ActionResult<Category>> Delete(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        private bool Exists(int id)
        {
            return _context.Category.Any(e => e.IdCategory == id);
        }
    }
}
