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
    public class UsersController : ControllerBase
    {
        private readonly ORDMNG_81310Context _context;
        private readonly IMapper mapper;

        public UsersController(ORDMNG_81310Context context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        //GET: api/Users
        [HttpGet]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetAll()
        {
            var Users = _context.Users.ToList();
            var UsersDTO = mapper.Map<List<UsersDTO>>(Users);
            return Ok(UsersDTO);
        }

        //Get: api/user/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyID([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Users = await _context.Users.FindAsync(id);
            //var UsersDTO = mapper.Map<List<UsersDTO>>(Users);
            if (Users == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UsersDTO>(Users));

        }
        [HttpPost]
        public async Task<IActionResult> Postusers([FromBody] UsersDTO usersDTO)
        {   //Converting DTO to Model
            var usersmodel = new Users
            {
                FirstName = usersDTO.FirstName,
                LastName = usersDTO.LastName,
                Email = usersDTO.Email,
                UserPassword = usersDTO.UserPassword,
                Phone = usersDTO.Phone,
                UserAddress = usersDTO.UserAddress,
                UserType = usersDTO.UserType
            };
            //Using model to create user
            _context.Users.Add(usersmodel);
            await _context.SaveChangesAsync();

            //Map model back to dto
            var userdto = new UsersDTO
            {
                FirstName = usersmodel.FirstName,
                LastName = usersmodel.LastName,
                Email = usersmodel.Email,
                UserPassword = usersmodel.UserPassword,
                Phone = usersmodel.Phone,
                UserAddress = usersmodel.UserAddress,
                UserType = usersmodel.UserType
            };
            return CreatedAtAction(nameof(GetbyID), new { id = usersmodel.UserId }, usersmodel);
        }
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers([FromRoute] int id, [FromBody] UsersDTO usersDto)
        {
            var users = mapper.Map<Users>(usersDto);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.UserId)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<UsersDTO>(users));
        }
        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}