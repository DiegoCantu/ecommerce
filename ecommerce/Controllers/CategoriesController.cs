using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Persistence;
using ecommerce.Application;
using AutoMapper;
using ecommerce.DTOs.Response;
using ecommerce.DTOs.Request;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesActions _categories;
        public CategoriesController(ContextDb context,IMapper mapper)
        {
            _categories = new CategoriesActions(context, mapper);
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategory()
        {
            return await _categories.Get();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetCategory(int id)
        {
            return await _categories.GetById(id);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryRequest category)
        {
            return await _categories.Put(id, category);
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> PostCategory(CategoryRequest category)
        {
            return await _categories.Post(category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryResponse>> DeleteCategory(int id)
        {
            return await _categories.Delete(id);
        }
    }
}
