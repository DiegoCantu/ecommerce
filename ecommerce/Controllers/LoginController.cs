using AutoMapper;
using ecommerce.Application;
using ecommerce.DTOs.Request;
using ecommerce.DTOs.Response;
using ecommerce.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserActions _users;
        public LoginController(ContextDb context,IMapper mapper)
        {
            _users = new UserActions(context, mapper);
        }

        // POST: api/Login
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest login)
        {
            return await _users.Login(login);
        }

    }
}
