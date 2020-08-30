using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Persistence;
using ecommerce.Application;
using AutoMapper;
using ecommerce.DTOs.Request;
using ecommerce.DTOs.Response;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductActions _product;
        public ProductsController(ContextDb context,IMapper mapper)
        {
            _product = new ProductActions(context, mapper);
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProduct()
        {
            return await _product.Get();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProduct(int id)
        {
            return await _product.GetById(id);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductRequest product)
        {
            return await _product.Put(id, product);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductResponse>> PostProduct(ProductRequest product)
        {
            return await _product.Post(product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductResponse>> DeleteProduct(int id)
        {
            return await _product.Delete(id);
        }

    }
}
