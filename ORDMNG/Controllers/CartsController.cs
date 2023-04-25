using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORDMNG.DTO;
using ORDMNG.Models;

namespace ORDMNG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ORDMNG_81310Context _context;
        private readonly IMapper mapper;

        public CartsController(ORDMNG_81310Context context,IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Carts
        [HttpGet]
        //public IEnumerable<Cart> GetCart()
        //{
        //    return _context.Cart;
        //}
        public IActionResult GetCart()
        {
            var Carts = _context.Cart.ToList();
            var cartsDTOs = mapper.Map<List<CartsDTO>>(Carts);
            return Ok(cartsDTOs);
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCart([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _context.Cart.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CartsDTO>(cart));
        }

        // PUT: api/Carts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart([FromRoute] int id, [FromBody] CartsDTO cart)
        {
            var carts = mapper.Map<CartsDTO>(cart);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        [HttpPost]
        public async Task<IActionResult> PostCart([FromBody] CartsDTO cartDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cart = mapper.Map<Cart>(cartDTO);
            await _context.Cart.AddAsync(cart);
            var carttodto = mapper.Map<CartsDTO>(cart);
            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.CartId }, cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<CartsDTO>(cart));
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.CartId == id);
        }
    }
}