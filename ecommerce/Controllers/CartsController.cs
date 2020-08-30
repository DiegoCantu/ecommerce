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
    public class CartsController : ControllerBase
    {
        private readonly CartActions _cart;
        public CartsController(ContextDb context,IMapper mapper)
        {
            _cart = new CartActions(context, mapper);
        }

        // GET: api/Carts | JWT
        //[HttpGet, Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartResponse>>> GetCart()
        {
            return await _cart.Get();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartResponse>> GetCart(int id)
        {
            return await _cart.GetById(id);
        }

        // PUT: api/Carts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, CartRequest cart)
        {
            return await _cart.Put(id, cart);
        }

        // POST: api/Carts
        [HttpPost]
        public async Task<ActionResult<CartResponse>> PostCart(CartRequest cart)
        {
            return await _cart.Post(cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartResponse>> DeleteCart(int id)
        {
            return await _cart.Delete(id);
        }
    }
}
