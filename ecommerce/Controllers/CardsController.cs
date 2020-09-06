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
    public class CardsController : ControllerBase
    {
        private readonly CardActions _cards;
        public CardsController(ContextDb context, IMapper mapper)
        {
            _cards = new CardActions(context, mapper);
        }

        // GET: api/Cards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardResponse>>> GetCard()
        {
            return await _cards.Get();
        }

        // GET: api/Cards/5
        [HttpGet("{email}/{numberCard}")]
        public async Task<ActionResult<CardResponse>> GetCard(string email, string numberCard)
        {
            return await _cards.GetById(email, numberCard);
        }

        // PUT: api/Cards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, CardRequest card)
        {
            return await _cards.Put(id,card);
        }

        // POST: api/Cards
        [HttpPost]
        public async Task<ActionResult<CardResponse>> PostCard(CardRequest card)
        {
            return await _cards.Post(card) ;
        }

        // DELETE: api/Cards/5
        [HttpDelete("{Email}/{numberCard}")]
        public async Task<ActionResult<CardResponse>> DeleteCard(string email, string numberCard)
        {
            return await _cards.Delete(email, numberCard);
        }
    }
}
