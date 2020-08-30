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
    public class PurchasesController : ControllerBase
    {
        private readonly PurchaseActions _purchase;
        public PurchasesController(ContextDb context,IMapper mapper)
        {
            _purchase = new PurchaseActions(context, mapper);
        }

        // GET: api/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseResponse>>> GetPurchase()
        {
            return await _purchase.Get();
        }

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseResponse>> GetPurchase(int id)
        {
            return await _purchase.GetByid(id);
        }

        // PUT: api/Purchases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase(int id, PurchaseRequest purchase)
        {
            return await _purchase.Put(id, purchase);
        }

        // POST: api/Purchases
        [HttpPost]
        public async Task<ActionResult<PurchaseResponse>> PostPurchase(PurchaseRequest purchase)
        {
            return await _purchase.Post(purchase);
        }

        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseResponse>> DeletePurchase(int id)
        {
            return await _purchase.Delete(id);
        }
    }
}
