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
    public class ShippingsController : ControllerBase
    {
        private readonly ORDMNG_81310Context _context;
        private readonly IMapper mapper;

        public ShippingsController(ORDMNG_81310Context context,IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Shippings
        [HttpGet]
        //public IEnumerable<Shipping> GetShipping()
        //{
        //    return _context.Shipping;
        //}
        public async Task<IActionResult> getAllShipping()
        {
            var shipping = await _context.Shipping.Select(e=>mapper.Map<ShippingDTO>(e)).ToListAsync();
            return Ok(shipping);
        }

        // GET: api/Shippings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipping([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipping = await _context.Shipping.FindAsync(id);

            if (shipping == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ShippingDTO>(shipping));
        }

        // PUT: api/Shippings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipping([FromRoute] int id, [FromBody] ShippingDTO shipping)
        {
            var shippingmodel = mapper.Map<Shipping>(shipping);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shipping.ShipId)
            {
                return BadRequest();
            }

            _context.Entry(shipping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingExists(id))
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

        // POST: api/Shippings
        [HttpPost]
        public async Task<IActionResult> PostShipping([FromBody] ShippingDTO shipping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var shippingmodel = mapper.Map<Shipping>(shipping);
            await _context.Shipping.AddAsync(shippingmodel);
            var shippingtodto = mapper.Map<ShippingDTO>(shippingmodel);
            await _context.SaveChangesAsync();

            //_context.Shipping.Add(shipping);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipping", new { id = shipping.ShipId }, shipping);
        }

        // DELETE: api/Shippings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipping([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipping = await _context.Shipping.FindAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }

            _context.Shipping.Remove(shipping);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<ShippingDTO>(shipping));
        }

        private bool ShippingExists(int id)
        {
            return _context.Shipping.Any(e => e.ShipId == id);
        }
    }
}