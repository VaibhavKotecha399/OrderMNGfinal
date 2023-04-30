using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORDMNG.DTO;
using ORDMNG.Models;

namespace ORDMNG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartItemsController : ControllerBase
    {
        private readonly ORDMNG_81310Context _context;
        private readonly IMapper mapper;

        public CartItemsController(ORDMNG_81310Context context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/CartItems
        [HttpGet]
        //public IEnumerable<CartItems> GetCartItems()
        //{
        //    return _context.CartItems;
        //}
        public async Task<IActionResult> GetAllCartItems()
        {
            var CartItems = await _context.CartItems.ToListAsync();
            var cartsItemsDTOs = mapper.Map<List<CartItemsDTO>>(CartItems);
            return Ok(cartsItemsDTOs);
        }

        // GET: api/CartItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartItems([FromRoute] int id)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartItems = await _context.CartItems.FindAsync(id);

            if (cartItems == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CartItems>(cartItems));
        }

        // PUT: api/CartItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartItems([FromRoute] int id, [FromBody] CartItemsDTO cartItems)
        {
            var cartItem = mapper.Map<CartsDTO>(cartItems);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartItems.CartItemId)
            {
                return BadRequest();
            }

            _context.Entry(cartItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemsExists(id))
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

        // POST: api/CartItems
        [HttpPost]
        public async Task<IActionResult> PostCartItems([FromBody] CartItemsDTO cartItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cartItem = mapper.Map<CartItems>(cartItems);
            await _context.CartItems.AddAsync(cartItem);
            var carttodto = mapper.Map<CartItemsDTO>(cartItems);
            await _context.SaveChangesAsync();
           

            return CreatedAtAction("GetCartItems", new { id = cartItems.CartItemId }, cartItems);
        }

        // DELETE: api/CartItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartItems = await _context.CartItems.FindAsync(id);
            if (cartItems == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(cartItems);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<CartItemsDTO>(cartItems));
        }

        private bool CartItemsExists(int id)
        {
            return _context.CartItems.Any(e => e.CartItemId == id);
        }
    }
}