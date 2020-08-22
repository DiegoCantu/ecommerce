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
    public class CardsController : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly CardActions _cards;
        public CardsController(ContextDb context)
        {
            _context = context;
            _cards = new CardActions(_context);
        }

        // GET: api/Cards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetCard()
        {
            return await _cards.Get();
        }

        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            return await _cards.GetById(id);
        }

        // PUT: api/Cards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, Card card)
        {
            return await _cards.Put(id, card);
        }

        // POST: api/Cards
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(Card card)
        {
            return await _cards.Post(card) ;
        }

        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Card>> DeleteCard(int id)
        {
            return await _cards.Delete(id);
        }
    }
}
