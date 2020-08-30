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
    public class CartDetailsController : ControllerBase
    {
        private readonly CartDetailActions _cardDetail;
        public CartDetailsController(ContextDb context,IMapper mapper)
        {
            _cardDetail = new CartDetailActions(context, mapper);
        }

        // GET: api/CartDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartDetailResponse>>> GetCartDetail()
        {
            return await _cardDetail.Get();
        }

        // GET: api/CartDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDetailResponse>> GetCartDetail(int id)
        {
            return await _cardDetail.GetById(id);
        }

        // PUT: api/CartDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartDetail(int id, CartDetailRequest cartDetail)
        {
            return await _cardDetail.Put(id,cartDetail);
        }

        // POST: api/CartDetails
        [HttpPost]
        public async Task<ActionResult<CartDetailResponse>> PostCartDetail(CartDetailRequest cartDetail)
        {
            return await _cardDetail.Post(cartDetail);
        }

        // DELETE: api/CartDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartDetailResponse>> DeleteCartDetail(int id)
        {
            return await _cardDetail.Delete(id);
        }
    }
}
