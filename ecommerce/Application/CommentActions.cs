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
    public class CommentActions : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        public CommentActions(ContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<CommentResponse>>> Get()
        {
            var commentModel = await _context.Comment.ToListAsync();
            // Model to Dto:
            var commentDto = _mapper.Map<List<Comment>, List<CommentResponse>>(commentModel);
            return commentDto;
        }

        public async Task<ActionResult<CommentResponse>> GetById(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            // Model to Dto:
            var commentDto = _mapper.Map<Comment, CommentResponse>(comment);
            return commentDto;
        }

        public async Task<ActionResult<IEnumerable<CommentResponse>>> GetByIdProduct(int id)
        {
            var comment = await _context.Comment.Where(x => x.IdProduct == id).ToListAsync();
            if (comment == null)
            {
                return NotFound();
            }
            // Model to Dto:
            var commentDto = _mapper.Map<List<Comment>, List<CommentResponse>>(comment);
            return commentDto;
        }

        public async Task<IActionResult> Put(int id, CommentRequest comment)
        {
            if (id != comment.IdComment)
            {
                return BadRequest();
            }
            // Dto to Model:
            Comment commentModel = new Comment()
            {
                IdComment = comment.IdComment,
                IdProduct = comment.IdProduct,
                Name = comment.Name,
                Post = comment.Post,
                Rating = comment.Rating

            };
            _context.Entry(commentModel).State = EntityState.Modified;

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

        public async Task<ActionResult<CommentResponse>> Post(CommentRequest comment)
        {
            // Dto to Model:
            Comment commentModel = new Comment()
            {
                IdProduct = comment.IdProduct,
                Name = comment.Name,
                Post = comment.Post,
                Rating = comment.Rating

            };
            _context.Comment.Add(commentModel);
            await _context.SaveChangesAsync();
            comment.IdComment = commentModel.IdComment;
            return CreatedAtAction("GetComment", new { id = comment.IdComment }, comment);
        }


        public async Task<ActionResult<CommentResponse>> Delete(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();
            // Model to Dto:
            var commentDto = _mapper.Map<Comment, CommentResponse>(comment);
            return commentDto;
        }

        private bool Exists(int id)
        {
            return _context.Comment.Any(e => e.IdComment == id);
        }
    }
}
