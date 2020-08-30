using AutoMapper;
using ecommerce.DTOs.Request;
using ecommerce.DTOs.Response;
using ecommerce.Helper;
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
    public class ProductActions : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        public ProductActions(ContextDb context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<ProductResponse>>> Get()
        {
            var productModel = await _context.Product.ToListAsync();
            // Model to Dto:
            var productDto = _mapper.Map<List<Product>, List<ProductResponse>>(productModel);
            // Get Comments:
            CommentActions commentActions = new CommentActions(_context,_mapper);
            foreach (var product in productDto)
            {
                product.Comments = new Collection<CommentResponse>();
                var commentsList = await commentActions.GetByIdProduct(product.IdProduct);
                foreach (var comment in commentsList.Value)
                {
                    product.Comments.Add(comment);
                }
                if (product.ImgApproved == false)
                {
                    product.Img = "/waiting.png";
                }
            }
            return productDto;
        }

        public async Task<ActionResult<ProductResponse>> GetById(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            // Model to Dto:
            var productDto = _mapper.Map<Product, ProductResponse>(product);
            // Get Comments:
            CommentActions commentActions = new CommentActions(_context, _mapper);
            productDto.Comments = new Collection<CommentResponse>();
            var commentsList = await commentActions.GetByIdProduct(product.IdProduct);
            foreach (var comment in commentsList.Value)
            {
                productDto.Comments.Add(comment);
            }
            return productDto;
        }

        public async Task<IActionResult> Put(int id, ProductRequest product)
        {
            if (id != product.IdProduct)
            {
                return BadRequest();
            }
            // Dto to Model:
            Product productModel = new Product()
            {
                IdProduct = product.IdProduct,
                Description = product.Description,
                IdCategory = product.IdCategory,
                Img = product.Img,
                Rating = product.Rating,
                Sku = product.Sku,
                SubHeader = product.SubHeader,
                Title = product.Title,
                UnitPrice = product.UnitPrice,
                ImgApproved = false
            };
            _context.Entry(productModel).State = EntityState.Modified;

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

        public async Task<ActionResult<ProductResponse>> Post(ProductRequest product)
        {
            // Dto to Model:
            Product productModel = new Product()
            {
                Description = product.Description,
                IdCategory = product.IdCategory,
                Img = "/Images/" + product.Sku + ".png",
                Rating = product.Rating,
                Sku = product.Sku,
                SubHeader = product.SubHeader,
                Title = product.Title,
                UnitPrice = product.UnitPrice,
                Quantity = 1,
                ImgApproved = false
            };
            _context.Product.Add(productModel);
            await _context.SaveChangesAsync();
            product.IdProduct = productModel.IdProduct;

            UploadImg.Save(product.Sku, product.Img, "ImgProducts");

            return CreatedAtAction("GetProduct", new { id = product.IdProduct }, product);
        }

        public async Task<ActionResult<ProductResponse>> Delete(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            // Model to Dto:
            var productDto = _mapper.Map<Product, ProductResponse>(product);
            return productDto;
        }

        private bool Exists(int id)
        {
            return _context.Product.Any(e => e.IdProduct == id);
        }
    }
}
