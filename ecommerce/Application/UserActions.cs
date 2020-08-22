using ecommerce.Helper;
using ecommerce.Models;
using ecommerce.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Application
{
    public class UserActions : ControllerBase
    {
        private readonly ContextDb _context;
        public UserActions(ContextDb context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        public async Task<IActionResult> Put(int id, User user)
        {
            if (id != user.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

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

        public async Task<ActionResult<User>> Post(User user)
        {
            user = JsonConvert.DeserializeObject<User>(Detect.BadWords(JsonConvert.SerializeObject(user)));
            user.Password = Cryptography.HashPassword(user.Password);
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.IdUser }, user);
        }

        public async Task<ActionResult<User>> Delete(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private bool Exists(int id)
        { 
            return _context.User.Any(e => e.IdUser == id);
        }

    }
}
