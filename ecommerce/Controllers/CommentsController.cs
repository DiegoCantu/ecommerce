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
    public class CommentsController : ControllerBase
    {
        private readonly CommentActions _comment;
        public CommentsController(ContextDb context,IMapper mapper)
        {
            _comment = new CommentActions(context, mapper);
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentResponse>>> GetComment()
        {
            return await _comment.Get();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentResponse>> GetComment(int id)
        {
            return await _comment.GetById(id);
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, CommentRequest comment)
        {
            return await _comment.Put(id, comment);
        }

        // POST: api/Comments
        [HttpPost]
        public async Task<ActionResult<CommentResponse>> PostComment(CommentRequest comment)
        {
            return await _comment.Post(comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommentResponse>> DeleteComment(int id)
        {
            return await _comment.Delete(id);
        }
    }
}
