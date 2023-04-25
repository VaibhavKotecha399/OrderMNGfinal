using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORDMNG.Models;

namespace ORDMNG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ORDMNG_81310Context _context;

        public CartItemsController(ORDMNG_81310Context context)
        {
            _context = context;
        }

        // GET: api/CartItems
        [HttpGet]
        public IEnumerable<CartItems> GetCartItems()
        {
            return _context.CartItems;
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

            return Ok(cartItems);
        }

        // PUT: api/CartItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartItems([FromRoute] int id, [FromBody] CartItems cartItems)
        {
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
        public async Task<IActionResult> PostCartItems([FromBody] CartItems cartItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CartItems.Add(cartItems);
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

            return Ok(cartItems);
        }

        private bool CartItemsExists(int id)
        {
            return _context.CartItems.Any(e => e.CartItemId == id);
        }
    }
}