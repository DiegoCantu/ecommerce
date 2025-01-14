﻿using AutoMapper;
using ecommerce.DTOs.Request;
using ecommerce.DTOs.Response;
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
        private readonly IMapper _mapper;
        public UserActions(ContextDb context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<UserResponse>>> Get()
        {
            var userModel = await _context.User.ToListAsync();
            var userDto = _mapper.Map<List<User>, List<UserResponse>>(userModel);
            return userDto;
        }

        public async Task<ActionResult<LoginResponse>> GetById(int id)
        {
            var user = await _context.User.Where(x => x.IdUser == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }
            LoginResponse loginResponseDto = new LoginResponse();
            AddressActions addressActions = new AddressActions(_context, _mapper);
            loginResponseDto.Addresses = addressActions.GetByEmail(user.Email).Result.Value;
            CardActions cardActions = new CardActions(_context, _mapper);
            loginResponseDto.Cards = cardActions.GetByEmail(user.Email).Result.Value;
            CartActions cartActions = new CartActions(_context, _mapper);
            loginResponseDto.Carts = cartActions.GetByEmail(user.Email).Result.Value;
            PurchaseActions purchaseActions = new PurchaseActions(_context, _mapper);
            loginResponseDto.Purchases = purchaseActions.GetByEmail(user.Email).Result.Value;
            loginResponseDto.JWT = JWT.GetToken();
            loginResponseDto.IdUser = user.IdUser;
            loginResponseDto.Email = user.Email;
            loginResponseDto.Name = user.Name;
            loginResponseDto.LastName = user.LastName;
            loginResponseDto.SecondLastName = user.SecondLastName;

            return loginResponseDto;
        }

        public async Task<IActionResult> Put(int id, UserRequest user)
        {
            if (id != user.IdUser)
            {
                return BadRequest();
            }
            User userModel = new User()
            {
                IdUser = user.IdUser,
                Name = user.Name,
                LastName = user.LastName,
                SecondLastName = user.SecondLastName,
            };
            _context.Entry(userModel).State = EntityState.Modified;

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

        public async Task<ActionResult<UserResponse>> Post(UserRequest user)
        {
            user = JsonConvert.DeserializeObject<UserRequest>(Detect.BadWords(JsonConvert.SerializeObject(user)));
            user.Password = Cryptography.HashPassword(user.Password);
            User userModel = new User()
            {
                Name = user.Name,
                LastName = user.LastName,
                SecondLastName = user.SecondLastName,
                Email = user.Email,
                Password = user.Password
            };
            _context.User.Add(userModel);
            await _context.SaveChangesAsync();
            user.IdUser = userModel.IdUser;
            // Model to Response:
            var userDto = _mapper.Map<User, UserResponse>(userModel);
            return CreatedAtAction("GetUser", new { id = userDto.IdUser }, userDto);
        }

        public async Task<ActionResult<UserResponse>> Delete(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            // Model to Dto:
            var userDto = _mapper.Map<User, UserResponse>(user);
            return Ok(userDto);
        }

        private bool Exists(int id)
        {
            return _context.User.Any(e => e.IdUser == id);
        }

        public async Task<ActionResult<LoginResponse>> Login(LoginRequest login)
        {
            if (login == null)
            {
                return BadRequest("Solicitud de cliente no válida");
            }
            var dbpass = await _context.User.Where(x => x.Email == login.Email).FirstOrDefaultAsync();
            if (dbpass != null)
            {
                if (Cryptography.VerifyPassword(dbpass.Password, login.Password))
                {
                    LoginResponse loginResponseDto = new LoginResponse();
                    AddressActions addressActions = new AddressActions(_context,_mapper);
                    loginResponseDto.Addresses = addressActions.GetByEmail(login.Email).Result.Value;
                    CardActions cardActions = new CardActions(_context, _mapper);
                    loginResponseDto.Cards = cardActions.GetByEmail(login.Email).Result.Value;
                    CartActions cartActions = new CartActions(_context, _mapper);
                    loginResponseDto.Carts = cartActions.GetByEmail(login.Email).Result.Value;
                    PurchaseActions purchaseActions = new PurchaseActions(_context, _mapper);
                    loginResponseDto.Purchases = purchaseActions.GetByEmail(login.Email).Result.Value;
                    loginResponseDto.IdUser = dbpass.IdUser;
                    loginResponseDto.JWT = JWT.GetToken();
                    loginResponseDto.Name = dbpass.Name;
                    loginResponseDto.LastName = dbpass.LastName;
                    loginResponseDto.SecondLastName = dbpass.SecondLastName;
                    return Ok(loginResponseDto);
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
