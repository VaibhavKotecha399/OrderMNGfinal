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
    public class ProductsController : ControllerBase
    {
        private readonly ORDMNG_81310Context _context;
        private readonly IMapper mapper;

        public ProductsController(ORDMNG_81310Context context,IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public  async Task<IActionResult> GetProducts()
        {

            var products = await _context.Products.ToListAsync();
            
            return Ok(mapper.Map<List<ProductsDTO>>(products));
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProductsDTO>(products));
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts([FromRoute] int id, [FromBody] ProductsDTO products)
        {
            var product = mapper.Map<Products>(products);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != products.Pid)
            {
                return BadRequest();
            }

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
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
        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProducts([FromBody]  ProductsDTO productsDto)
        {
            if (ModelState.IsValid)
            {
                var products = mapper.Map<Products>(productsDto);

                await _context.Products.AddAsync(products);

                var productsDto1 = mapper.Map<ProductsDTO>(products);


                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProducts", new { id = products.Pid }, products);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<ProductsDTO>(products));
        }
        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Pid == id);
        }
    }
}