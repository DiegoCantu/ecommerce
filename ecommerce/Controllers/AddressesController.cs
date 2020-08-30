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
    public class AddressesController : ControllerBase
    {
        private readonly AddressActions _address;
        public AddressesController(ContextDb context, IMapper mapper)
        {
            _address = new AddressActions(context, mapper);
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressResponse>>> GetAddress()
        {
            return await _address.Get();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressResponse>> GetAddress(int id)
        {
            return await _address.GetById(id);
        }

        // PUT: api/Addresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, AddressRequest address)
        {
            return await _address.Put(id, address);
        }

        // POST: api/Addresses
        [HttpPost]
        public async Task<ActionResult<AddressResponse>> PostAddress(AddressRequest address)
        {
            return await _address.Post(address);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AddressResponse>> DeleteAddress(int id)
        {
            return await _address.Delete(id); ;
        }
    }
}
