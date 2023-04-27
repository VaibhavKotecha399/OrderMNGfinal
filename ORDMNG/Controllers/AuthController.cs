using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ORDMNG.DTO;
using ORDMNG.Models;
using ORDMNG.Repositories;

namespace ORDMNG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
         
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;
        private readonly ORDMNG_81310Context dbcontext;
        private readonly IMapper mapper;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository,  ORDMNG_81310Context dbcontext, IMapper mapper)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.dbcontext = dbcontext;
            this.mapper = mapper;
        }


        [HttpPost]
        [Route("Register")]
        //POST:/api/Auth/Register
        //public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        //{
        //    var identityUser = new IdentityUser
        //    {
        //        UserName = registerRequestDTO.Username,
        //        Email = registerRequestDTO.Username
        //    };
        //    var identityResult = await userManager.CreateAsync(identityUser, registerRequestDTO.Password);
        //    if (identityResult.Succeeded)
        //    {
        //        //Add roles to this user
        //        if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
        //        {
        //            identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);

        //            if (identityResult.Succeeded)
        //            {
        //                return Ok("User was Registered! Please Login..");
        //            }
        //        }

        //    }
        //    return BadRequest("Something went Wrong!!!");
        //}
        //
        //POST:/api/Auth/Login
        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> Login ([FromBody] LoginRequestDTO loginRequestDTO)
        //{
        //   var user = await userManager.FindByEmailAsync(loginRequestDTO.Username);
        //    if (user != null)
        //    {
        //      var checkPassResult=  await userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
        //        if (checkPassResult)
        //        {
        //            //Create token 
        //            return Ok();
        //        }
        //    }
        //    return BadRequest("Username si wrong ");
        //}

        public async Task<IActionResult> Register([FromBody] UsersDTO userDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = userDto.Email,
                Email = userDto.Email
            };

            var identityResult = await userManager.CreateAsync(identityUser, userDto.UserPassword);
            var user = mapper.Map<Users>(userDto);

            if (identityResult.Succeeded)
            {
                //Add roles to this user
                if (userDto.UserType != null && userDto.UserType.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, userDto.UserType);
                    user.UserType = userDto.UserType[0];
                    await dbcontext.Users.AddAsync(user);


                    if (identityResult.Succeeded)
                    {
                        await dbcontext.SaveChangesAsync();
                        return Ok("User was Registered! Please Login..");
                    }
                }

            }
            return BadRequest("Something went Wrong!!!");
        }

        //POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);
            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    //Get roles for the User
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        //create token
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(response);
                    }

                }
            }
            return BadRequest("Username or Password Incorrect");
        }
    }
}


