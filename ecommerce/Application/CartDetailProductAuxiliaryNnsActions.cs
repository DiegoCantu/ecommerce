using ecommerce.Models;
using ecommerce.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Application
{
    public class CartDetailProductAuxiliaryNnsActions
    {
        private readonly ContextDb _context;
        public CartDetailProductAuxiliaryNnsActions(ContextDb context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartDetailProductAuxiliaryNn>> GetCartDetailProductAuxiliaryNn()
        {
            return await _context.CartDetailProductAuxiliaryNn.ToListAsync();
        }

        public async Task<CartDetailProductAuxiliaryNn> GetCartDetailProductAuxiliaryNn(int id)
        {
            var cartDetailProductAuxiliaryNn = await _context.CartDetailProductAuxiliaryNn.FindAsync(id);

            if (cartDetailProductAuxiliaryNn == null)
            {
                return null;
            }

            return cartDetailProductAuxiliaryNn;
        }

        public async Task<CartDetailProductAuxiliaryNn> PutCartDetailProductAuxiliaryNn(int id, CartDetailProductAuxiliaryNn cartDetailProductAuxiliaryNn)
        {
            if (id != cartDetailProductAuxiliaryNn.IdCartDetailProduct)
            {
                return null;
            }

            _context.Entry(cartDetailProductAuxiliaryNn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartDetailProductAuxiliaryNnExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return cartDetailProductAuxiliaryNn;
        }

        public async Task<CartDetailProductAuxiliaryNn> PostCartDetailProductAuxiliaryNn(CartDetailProductAuxiliaryNn cartDetailProductAuxiliaryNn)
        {
            _context.CartDetailProductAuxiliaryNn.Add(cartDetailProductAuxiliaryNn);
            await _context.SaveChangesAsync();

            return cartDetailProductAuxiliaryNn;
        }

        public async Task<CartDetailProductAuxiliaryNn> DeleteCartDetailProductAuxiliaryNn(int id)
        {
            var cartDetailProductAuxiliaryNn = await _context.CartDetailProductAuxiliaryNn.FindAsync(id);
            if (cartDetailProductAuxiliaryNn == null)
            {
                return null;
            }

            _context.CartDetailProductAuxiliaryNn.Remove(cartDetailProductAuxiliaryNn);
            await _context.SaveChangesAsync();
            return cartDetailProductAuxiliaryNn;
        }

        private bool CartDetailProductAuxiliaryNnExists(int id)
        {
            return _context.CartDetailProductAuxiliaryNn.Any(e => e.IdCartDetailProduct == id);
        }
    }
}
