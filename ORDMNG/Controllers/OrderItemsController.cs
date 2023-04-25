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
    public class OrderItemsController : ControllerBase
    {
        private readonly ORDMNG_81310Context _context;
        private readonly IMapper mapper;

        public OrderItemsController(ORDMNG_81310Context context,IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/OrderItems
        [HttpGet]
        //public IEnumerable<OrderItems> GetOrderItems()
        //{
        //    return _context.OrderItems;
        //}
        public async Task<IActionResult> GetAllOrderItems()
        {
            var orderItems = await _context.OrderItems.ToListAsync();
            return Ok(mapper.Map<OrderItemsDTO>(orderItems));
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItems([FromRoute] int id)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderItems = await _context.OrderItems.FindAsync(id);

            if (orderItems == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<OrderItemsDTO>(orderItems));
        }

        // PUT: api/OrderItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItems([FromRoute] int id, [FromBody] OrderItemsDTO orderItems)
        {
            var orderItemsmodel = mapper.Map<OrderItems>(orderItems);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderItems.Oiid)
            {
                return BadRequest();
            }

            _context.Entry(orderItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemsExists(id))
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

        // POST: api/OrderItems
        [HttpPost]
        public async Task<IActionResult> PostOrderItems([FromBody] OrderItemsDTO orderItemsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderItems = mapper.Map<OrderItems>(orderItemsDTO);
            await _context.OrderItems.AddAsync(orderItems);
            var orderItemstodto = mapper.Map<OrderItems>(orderItems);
            await _context.SaveChangesAsync();
            //_context.OrderItems.Add(orderItems);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItems", new { id = orderItems.Oiid }, orderItems);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderItems = await _context.OrderItems.FindAsync(id);
            if (orderItems == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItems);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<OrderItemsDTO>(orderItems));
        }

        private bool OrderItemsExists(int id)
        {
            return _context.OrderItems.Any(e => e.Oiid == id);
        }
    }
}