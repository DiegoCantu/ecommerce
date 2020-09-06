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
    public class CardActions : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        public CardActions(ContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<CardResponse>>> Get()
        {
            var cardModel = await _context.Card.ToListAsync();
            List<CardResponse> cardDtos = new List<CardResponse>();
            foreach (var model in cardModel)
            {
                CardResponse cardDto = new CardResponse
                {
                    CardName = model.CardName,
                    CreateDate = model.CreateDate,
                    Email = model.Email,
                    ExpireDate = model.ExpireDate,
                    IdCard = model.IdCard,
                    InUse = model.InUse,
                    NumberCard = model.NumberCard,
                    UsernameCard = model.UsernameCard
                };
                cardDtos.Add(cardDto);
            }
            return cardDtos;
        }

        public async Task<ActionResult<CardResponse>> GetById(string Email, string NumberCard)
        {
            var card = await _context.Card.Where(c => c.Email == Email && c.NumberCard == NumberCard).FirstOrDefaultAsync();
            if (card == null)
            {
                return NotFound();
            }
            CardResponse cardDto = new CardResponse
            {
                CardName = card.CardName,
                CreateDate = card.CreateDate,
                Email = card.Email,
                ExpireDate = card.ExpireDate,
                IdCard = card.IdCard,
                InUse = card.InUse,
                NumberCard = card.NumberCard,
                UsernameCard = card.UsernameCard
            };
            return cardDto;
        }

        public async Task<ActionResult<IEnumerable<CardResponse>>> GetByEmail(string email)
        {
            var cardModel = await _context.Card.Where(x => x.Email == email).ToListAsync();
            List<CardResponse> cardDtos = new List<CardResponse>();
            foreach (var model in cardModel)
            {
                CardResponse cardDto = new CardResponse
                {
                    CardName = model.CardName,
                    CreateDate = model.CreateDate,
                    Email = model.Email,
                    ExpireDate = model.ExpireDate,
                    IdCard = model.IdCard,
                    InUse = model.InUse,
                    NumberCard = model.NumberCard,
                    UsernameCard = model.UsernameCard
                };
                cardDtos.Add(cardDto);
            }
            return cardDtos;
        }

        public async Task<IActionResult> Put(int id, CardRequest card)
        {
            if (id != card.IdCard)
            {
                return BadRequest();
            }
            // Dto to Model:
            Card cardModel = new Card()
            {
                IdCard = card.IdCard,
                Email = card.Email,
                NumberCard = card.NumberCard,
                CardName = card.CardName,
                ExpireDate = card.ExpireDate,
                InUse = card.InUse,
                UsernameCard = card.UsernameCard,
            };
            _context.Entry(cardModel).State = EntityState.Modified;

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

        public async Task<ActionResult<CardResponse>> Post(CardRequest card)
        {
            // Dto to Model:
            Card cardModel = new Card()
            {
                CardName = card.CardName,
                Email = card.Email,
                ExpireDate = card.ExpireDate,
                InUse = card.InUse,
                NumberCard = card.NumberCard,
                UsernameCard = card.UsernameCard,
            };
            _context.Card.Add(cardModel);
            await _context.SaveChangesAsync();
            card.IdCard = cardModel.IdCard;
            return CreatedAtAction("GetCard", new { id = card.IdCard }, card);
        }

        public async Task<ActionResult<CardResponse>> Delete(string Email, string NumberCard)
        {
            var card = await _context.Card.FindAsync(Email, NumberCard);
            if (card == null)
            {
                return NotFound();
            }

            _context.Card.Remove(card);
            await _context.SaveChangesAsync();
            CardResponse cardDto = new CardResponse
            {
                CardName = card.CardName,
                CreateDate = card.CreateDate,
                Email = card.Email,
                ExpireDate = card.ExpireDate,
                IdCard = card.IdCard,
                InUse = card.InUse,
                NumberCard = card.NumberCard,
                UsernameCard = card.UsernameCard
            };
            return cardDto;
        }

        private bool Exists(int id)
        {
            return _context.Card.Any(e => e.IdCard == id);
        }
    }
}
