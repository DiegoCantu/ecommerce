using AutoMapper;
using ecommerce.DTOs.Request;
using ecommerce.DTOs.Response;
using ecommerce.Models;
using ecommerce.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Application
{
    public class CategoriesActions : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        public CategoriesActions(ContextDb context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<CategoryResponse>>> Get()
        {
            var categoryModel = await _context.Category.ToListAsync();
            // Model to Dto:
            var categoryDto = _mapper.Map<List<Category>, List<CategoryResponse>>(categoryModel);
            return categoryDto;
        }

        public async Task<ActionResult<CategoryResponse>> GetById(int id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            // Model to Dto:
            var categoryDto = _mapper.Map<Category, CategoryResponse>(category);
            return categoryDto;
        }

        public async Task<IActionResult> Put(int id, CategoryRequest category)
        {
            if (id != category.IdCategory)
            {
                return BadRequest();
            }
            // Dto to Model:
            Category categoryModel = new Category()
            {
                IdCategory = category.IdCategory,
                Name = category.Name,
            };
            _context.Entry(categoryModel).State = EntityState.Modified;

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

        public async Task<ActionResult<CategoryResponse>> Post(CategoryRequest category)
        {
            // Dto to Model:
            Category categoryModel = new Category()
            {
                Name = category.Name,
            };
            _context.Category.Add(categoryModel);
            await _context.SaveChangesAsync();
            category.IdCategory = categoryModel.IdCategory;
            return CreatedAtAction("GetCategory", new { id = category.IdCategory }, category);
        }

        public async Task<ActionResult<CategoryResponse>> Delete(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            // Model to Dto:
            var categoryDto = _mapper.Map<Category, CategoryResponse>(category);
            return categoryDto;
        }

        private bool Exists(int id)
        {
            return _context.Category.Any(e => e.IdCategory == id);
        }
    }
}
