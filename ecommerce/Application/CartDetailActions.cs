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
    public class CartDetailActions : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        public CartDetailActions(ContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<CartDetailResponse>>> Get()
        {
            var cartDetailModel = await _context.CartDetail.ToListAsync();
            // Model to Dto:
            var cartDetailDto = _mapper.Map<List<CartDetail>, List<CartDetailResponse>>(cartDetailModel);
            // Get Products:
            ProductActions productActions = new ProductActions(_context, _mapper);
            foreach (var cartDetail in cartDetailDto)
            {
                var product = await productActions.GetById(cartDetail.IdProduct);
                cartDetail.Product = product.Value;
            }
            return cartDetailDto;
        }

        public async Task<ActionResult<CartDetailResponse>> GetById(int id)
        {
            var cartDetail = await _context.CartDetail.FindAsync(id);

            if (cartDetail == null)
            {
                return NotFound();
            }
            // Model to Dto:
            var cardDetailDto = _mapper.Map<CartDetail, CartDetailResponse>(cartDetail);
            // Get Product:
            ProductActions productActions = new ProductActions(_context, _mapper);
            var product = await productActions.GetById(cartDetail.IdProduct);
            cardDetailDto.Product = product.Value;

            return cardDetailDto;
        }

        public async Task<ActionResult<IEnumerable<CartDetailResponse>>> GetByIdCart(int id)
        {
            var cartDetailModel = await _context.CartDetail.Where(x => x.IdCart == id).ToListAsync();
            if (cartDetailModel == null)
            {
                return NotFound();
            }
            // Model to Dto:
            var cartDetailDto = _mapper.Map<List<CartDetail>, List<CartDetailResponse>>(cartDetailModel);
            // Get Products:
            ProductActions productActions = new ProductActions(_context, _mapper);
            foreach (var cartDetail in cartDetailDto)
            {
                var product = await productActions.GetById(cartDetail.IdProduct);
                cartDetail.Product = product.Value;
            }
            return cartDetailDto;
        }

        public async Task<IActionResult> Put(int id, CartDetailRequest cartDetail)
        {
            if (id != cartDetail.IdCartDetail)
            {
                return BadRequest();
            }
            // Dto to Model:
            CartDetail cartDetailModel = new CartDetail()
            {
                IdCart = cartDetail.IdCart,
                IdProduct = cartDetail.IdProduct,
                Quantity = cartDetail.Quantity
            };
            _context.Entry(cartDetailModel).State = EntityState.Modified;

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

        public async Task<ActionResult<CartDetailResponse>> Post(CartDetailRequest cartDetail)
        {
            // Dto to Model:
            CartDetail cartDetailModel = new CartDetail()
            {
                IdCart = cartDetail.IdCart,
                IdProduct = cartDetail.IdProduct,
                Quantity = cartDetail.Quantity
            };
            _context.CartDetail.Add(cartDetailModel);
            await _context.SaveChangesAsync();
            cartDetail.IdCartDetail = cartDetailModel.IdCartDetail;
            CartDetailProductAuxiliaryNnsActions cartDetailProductAuxiliaryNnsActions = new CartDetailProductAuxiliaryNnsActions(_context);
            CartDetailProductAuxiliaryNn cartDetailProductAuxiliaryNn = new CartDetailProductAuxiliaryNn
            {
                IdCartDetail = cartDetail.IdCartDetail,
                IdProduct = cartDetail.IdProduct
            };
            await cartDetailProductAuxiliaryNnsActions.PostCartDetailProductAuxiliaryNn(cartDetailProductAuxiliaryNn);
            return CreatedAtAction("GetCartDetail", new { id = cartDetail.IdCartDetail }, cartDetail);
        }

        public async Task<ActionResult<CartDetailResponse>> Delete(int id)
        {
            var cartDetail = await _context.CartDetail.FindAsync(id);
            if (cartDetail == null)
            {
                return NotFound();
            }

            _context.CartDetail.Remove(cartDetail);
            await _context.SaveChangesAsync();
            // Model to Dto:
            var cartDetailDto = _mapper.Map<CartDetail, CartDetailResponse>(cartDetail);
            return cartDetailDto;
        }

        private bool Exists(int id)
        {
            return _context.CartDetail.Any(e => e.IdCartDetail == id);
        }
    }
}
