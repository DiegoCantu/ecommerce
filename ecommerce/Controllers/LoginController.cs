using ecommerce.Application;
using ecommerce.Models;
using ecommerce.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly UserActions _users;
        public LoginController(ContextDb context)
        {
            _context = context;
            _users = new UserActions(_context);
        }

        // POST: api/Login
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] Login login)
        {
            return await _users.Login(login);
        }

    }
}
