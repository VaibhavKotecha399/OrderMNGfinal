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
    public class ShipmentStgsController : ControllerBase
    {
        private readonly ORDMNG_81310Context _context;
        private readonly IMapper mapper;

        public ShipmentStgsController(ORDMNG_81310Context context,IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/ShipmentStgs
        [HttpGet]
        //public IEnumerable<ShipmentStg> GetShipmentStg()
        //{
        //    return _context.ShipmentStg;
        //}
        public async Task<IActionResult> GetAllShipStg()
        {
            var ShipStg = await _context.ShipmentStg.ToListAsync();
            return Ok(mapper.Map<ShipmentStgDTO>(ShipStg));
            
        }

        // GET: api/ShipmentStgs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipmentStg([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipmentStg = await _context.ShipmentStg.FindAsync(id);

            if (shipmentStg == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ShipmentStgDTO>(shipmentStg));
        }

        // PUT: api/ShipmentStgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipmentStg([FromRoute] int id, [FromBody] ShipmentStgDTO shipmentStg)
        {
            var shipmentStgsmodel = mapper.Map<ShipmentStg>(shipmentStg);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shipmentStg.ShipStg)
            {
                return BadRequest();
            }

            _context.Entry(shipmentStg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentStgExists(id))
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

        // POST: api/ShipmentStgs
        [HttpPost]
        public async Task<IActionResult> PostShipmentStg([FromBody] ShipmentStgDTO shipmentStgDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var shipmentStgmodel = mapper.Map<ShipmentStg>(shipmentStgDTO);
            await _context.ShipmentStg.AddAsync(shipmentStgmodel);
            var shipStgtodto = mapper.Map<ShippingDTO>(shipmentStgDTO);
            await _context.SaveChangesAsync();
            //_context.ShipmentStg.Add(shipmentStg);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipmentStg", new { id = shipmentStgmodel.ShipStg }, shipmentStgmodel);
        }

        // DELETE: api/ShipmentStgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipmentStg([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipmentStg = await _context.ShipmentStg.FindAsync(id);
            if (shipmentStg == null)
            {
                return NotFound();
            }

            _context.ShipmentStg.Remove(shipmentStg);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<ShipmentStgDTO>(shipmentStg));
        }

        private bool ShipmentStgExists(int id)
        {
            return _context.ShipmentStg.Any(e => e.ShipStg == id);
        }
    }
}