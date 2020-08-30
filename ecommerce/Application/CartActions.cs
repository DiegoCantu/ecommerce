using AutoMapper;
using ecommerce.DTOs.Request;
using ecommerce.DTOs.Response;
using ecommerce.Models;
using ecommerce.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Application
{
    public class CartActions : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        public CartActions(ContextDb context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<CartResponse>>> Get()
        {
            var cartModel = await _context.Cart.ToListAsync();
            // Model to Dto:
            var cartDto = _mapper.Map<List<Cart>, List<CartResponse>>(cartModel);
            // Get CartDetails:
            CartDetailActions cartDetailActions = new CartDetailActions(_context, _mapper);
            foreach (var cart in cartDto)
            {
                cart.CartDetails = new Collection<CartDetailResponse>();  
                var commentsList = await cartDetailActions.GetByIdCart(cart.IdCart);
                foreach (var comment in commentsList.Value)
                {
                    cart.CartDetails.Add(comment);
                }
            }
            return cartDto;
        }

        public async Task<ActionResult<CartResponse>> GetById(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            var cartDto = _mapper.Map<Cart, CartResponse>(cart);
            // Get CartDetails:
            CartDetailActions cartDetailActions = new CartDetailActions(_context, _mapper);
            cartDto.CartDetails = new Collection<CartDetailResponse>();
            var commentsList = await cartDetailActions.GetByIdCart(cart.IdCart);
            foreach (var comment in commentsList.Value)
            {
                cartDto.CartDetails.Add(comment);
            }
            return cartDto;
        }

        public async Task UpdateById(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart != null)
            {
                cart.Bought = true;
                _context.Entry(cart).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<IEnumerable<CartResponse>>> GetByEmail(string email)
        {
            var cartModel = await _context.Cart.Where(x => x.Email == email).ToListAsync();
            // Model to Dto:
            var cartDto = _mapper.Map<List<Cart>, List<CartResponse>>(cartModel);
            // Get CartDetails:
            CartDetailActions cartDetailActions = new CartDetailActions(_context, _mapper);
            foreach (var cart in cartDto)
            {
                cart.CartDetails = new Collection<CartDetailResponse>();
                var commentsList = await cartDetailActions.GetByIdCart(cart.IdCart);
                foreach (var comment in commentsList.Value)
                {
                    cart.CartDetails.Add(comment);
                }
            }
            return cartDto;
        }

        public async Task<IActionResult> Put(int id, CartRequest cart)
        {
            if (id != cart.IdCart)
            {
                return BadRequest();
            }
            // Dto to Model:
            Cart cartModel = new Cart()
            {
                IdCart = cart.IdCart,
                Email = cart.Email,
                Bought = cart.Bought,
                Total = cart.Total
            };
            _context.Entry(cartModel).State = EntityState.Modified;

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

        public async Task<ActionResult<CartResponse>> Post(CartRequest cart)
        {
            // Get the total:
            List<decimal> total = new List<decimal>();
            ProductActions productAction = new ProductActions(_context, _mapper);
            foreach (var detail in cart.CartDetails)
            {
                var product = await productAction.GetById(detail.IdProduct);
                total.Add(detail.Quantity * product.Value.UnitPrice);
            }

            // Dto to Model:
            Cart cartModel = new Cart()
            {
                Email = cart.Email,
                Bought = cart.Bought,
                Total = total.Sum()
            };

            _context.Cart.Add(cartModel);
            await _context.SaveChangesAsync();
            cart.IdCart = cartModel.IdCart;
            CartDetailActions cartDetailActions = new CartDetailActions(_context,_mapper);
            foreach (var detail in cart.CartDetails)
            {
                detail.IdCart = cart.IdCart;
                await cartDetailActions.Post(detail);
            }
            return CreatedAtAction("GetCart", new { id = cart.IdCart }, cart);
        }

        public async Task<ActionResult<CartResponse>> Delete(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            // Model to Dto:
            var cartDto = _mapper.Map<Cart, CartResponse>(cart);
            return cartDto;
        }

        private bool Exists(int id)
        {
            return _context.Cart.Any(e => e.IdCart == id);
        }
    }
}
