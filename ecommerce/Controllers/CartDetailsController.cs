using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Models;
using ecommerce.Persistence;
using ecommerce.Application;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailsController : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly CartDetailActions _cardDetail;
        public CartDetailsController(ContextDb context)
        {
            _context = context;
            _cardDetail = new CartDetailActions(_context);
        }

        // GET: api/CartDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartDetail>>> GetCartDetail()
        {
            return await _cardDetail.Get();
        }

        // GET: api/CartDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDetail>> GetCartDetail(int id)
        {
            return await _cardDetail.GetById(id);
        }

        // PUT: api/CartDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartDetail(int id, CartDetail cartDetail)
        {
            return await _cardDetail.Put(id,cartDetail);
        }

        // POST: api/CartDetails
        [HttpPost]
        public async Task<ActionResult<CartDetail>> PostCartDetail(CartDetail cartDetail)
        {
            return await _cardDetail.Post(cartDetail);
        }

        // DELETE: api/CartDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartDetail>> DeleteCartDetail(int id)
        {
            return await _cardDetail.Delete(id);
        }
    }
}
