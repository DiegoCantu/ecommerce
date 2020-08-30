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
    public class AddressActions : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        public AddressActions(ContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<AddressResponse>>> Get()
        {
            var address = await _context.Address.ToListAsync();
            // Model to Dto:
            var addressDto = _mapper.Map<List<Address>, List<AddressResponse>>(address);
            return addressDto;
        }

        public async Task<ActionResult<AddressResponse>> GetById(int id)
        {
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            // Model to Dto:
            var addressDto = _mapper.Map<Address, AddressResponse>(address);
            return addressDto;
        }

        public async Task<ActionResult<IEnumerable<AddressResponse>>> GetByEmail(string email)
        {
            var address = await _context.Address.Where(x => x.Email == email).ToListAsync();
            // Model to Dto:
            var addressDto = _mapper.Map<List<Address>, List<AddressResponse>>(address);
            return addressDto;
        }

        public async Task<IActionResult> Put(int id, AddressRequest address)
        {
            if (id != address.IdAddress)
            {
                return BadRequest();
            }
            // Dto to Model:
            Address addressModel = new Address()
            {
                IdAddress = address.IdAddress,
                BuyerName = address.BuyerName,
                City = address.City,
                Email = address.Email,
                InUse = address.InUse,
                Phone = address.Phone,
                PostalCode = address.PostalCode,
                State = address.State,
                Street = address.Street
            };
            _context.Entry(addressModel).State = EntityState.Modified;

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

        public async Task<ActionResult<AddressResponse>> Post(AddressRequest address)
        {
            // Dto to Model:
            Address addressModel = new Address()
            {
                BuyerName = address.BuyerName,
                City = address.City,
                Email = address.Email,
                InUse = address.InUse,
                Phone = address.Phone,
                PostalCode = address.PostalCode,
                State = address.State,
                Street = address.Street
            };
            _context.Address.Add(addressModel);
            await _context.SaveChangesAsync();
            address.IdAddress = addressModel.IdAddress;
            return CreatedAtAction("GetAddress", new { id = address.IdAddress }, address);
        }

        public async Task<ActionResult<AddressResponse>> Delete(int id)
        {
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            _context.Address.Remove(address);
            await _context.SaveChangesAsync();
            // Model to Dto:
            var addressDto = _mapper.Map<Address, AddressResponse>(address);
            return addressDto;
        }

        private bool Exists(int id)
        {
            return _context.Address.Any(e => e.IdAddress == id);
        }
    }
}
