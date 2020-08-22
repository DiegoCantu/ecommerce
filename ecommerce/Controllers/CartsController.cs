using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Models;
using ecommerce.Persistence;
using ecommerce.Application;
using Microsoft.AspNetCore.Authorization;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly CartsActions _cart;
        public CartsController(ContextDb context)
        {
            _context = context;
            _cart = new CartsActions(_context);
        }

        // GET: api/Carts | JWT
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        {
            return await _cart.Get();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            return await _cart.GetById(id);
        }

        // PUT: api/Carts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Cart cart)
        {
            return await _cart.Put(id, cart);
        }

        // POST: api/Carts
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            return await _cart.Post(cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cart>> DeleteCart(int id)
        {
            return await _cart.Delete(id);
        }
    }
}
