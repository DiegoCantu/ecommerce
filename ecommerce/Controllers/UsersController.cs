using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Application;
using ecommerce.Persistence;
using AutoMapper;
using ecommerce.DTOs.Response;
using ecommerce.DTOs.Request;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserActions _users;
        public UsersController(ContextDb context, IMapper mapper)
        {
            _users = new UserActions(context, mapper);
        }
        
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUser()
        {
            return await _users.Get();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginResponse>> GetUser(int id)
        {
            return await _users.GetById(id);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserRequest user)
        {
            return await _users.Put(id,user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserResponse>> PostUser(UserRequest user)
        {
            return await _users.Post(user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserResponse>> DeleteUser(int id)
        {
            return await _users.Delete(id);
        }
    }
}
