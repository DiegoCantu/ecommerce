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
    public class PurchaseActions : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        public PurchaseActions(ContextDb context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<PurchaseResponse>>> Get()
        {
            var purchaseModel = await _context.Purchase.ToListAsync();
            // Model to Dto:
            var purchaseDto = _mapper.Map<List<Purchase>, List<PurchaseResponse>>(purchaseModel);
            // Get Carts:
            CartActions cartActions = new CartActions(_context, _mapper);
            foreach (var purchase in purchaseDto)
            {
                var cart = await cartActions.GetById(purchase.IdCart);
                purchase.Cart = cart.Value;
            }
            return purchaseDto;
        }

        public async Task<ActionResult<PurchaseResponse>> GetByid(int id)
        {
            var purchase = await _context.Purchase.FindAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }
            // Model to Dto:
            var purchaseDto = _mapper.Map<Purchase, PurchaseResponse>(purchase);
            // Get Cart:
            CartActions cartActions = new CartActions(_context, _mapper);
            var cart = await cartActions.GetById(purchase.IdCart);
            purchaseDto.Cart = cart.Value;
            return purchaseDto;
        }

        public async Task<ActionResult<IEnumerable<PurchaseResponse>>> GetByEmail(string email)
        {
            var purchaseModel = await _context.Purchase.Where(x => x.Email == email).ToListAsync();
            // Model to Dto:
            var purchaseDto = _mapper.Map<List<Purchase>, List<PurchaseResponse>>(purchaseModel);
            // Get Carts:
            CartActions cartActions = new CartActions(_context, _mapper);
            foreach (var purchase in purchaseDto)
            {
                var cart = await cartActions.GetById(purchase.IdCart);
                purchase.Cart = cart.Value;
            }
            return purchaseDto;
        }

        public async Task<IActionResult> Put(int id, PurchaseRequest purchase)
        {
            if (id != purchase.IdPurchase)
            {
                return BadRequest();
            }
            // Dto to Model:
            Purchase purchaseModel = new Purchase()
            {
                IdPurchase = purchase.IdPurchase,
                Email = purchase.Email,
                IdCart = purchase.IdCart
            };
            _context.Entry(purchaseModel).State = EntityState.Modified;

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

        public async Task<ActionResult<PurchaseResponse>> Post(PurchaseRequest purchase)
        {
            // Dto to Model:
            Purchase purchaseModel = new Purchase()
            {
                Email = purchase.Email,
                IdCart = purchase.IdCart
            };
            _context.Purchase.Add(purchaseModel);
            await _context.SaveChangesAsync();
            purchase.IdPurchase = purchaseModel.IdPurchase;

            await UpdateCart(purchase.IdCart);

            return CreatedAtAction("GetPurchase", new { id = purchase.IdPurchase }, purchase);
        }

        private async Task UpdateCart(int idCart)
        {
            // Update status cart:
            CartActions cartActions = new CartActions(_context, _mapper);
            await cartActions.UpdateById(idCart);
        }

        public async Task<ActionResult<PurchaseResponse>> Delete(int id)
        {
            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();
            // Model to Dto:
            var purchaseDto = _mapper.Map<Purchase, PurchaseResponse>(purchase);
            return purchaseDto;
        }

        private bool Exists(int id)
        {
            return _context.Purchase.Any(e => e.IdPurchase == id);
        }
    }
}
