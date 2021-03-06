using LoginMicroservice.Data;
using LoginMicroservice.DTO;
using LoginMicroservice.Interfaces;
using LoginMicroservice.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly ILoginService _loginService;


        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns>UserDto</returns>
        //[HttpPost("Register")]
        //public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        //{
        //    using var hmac = new HMACSHA512();
        //    var user = new User
        //    {
        //        UserName = registerDto.UserName,
        //        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        //        PasswordSalt = hmac.Key
        //    };
        //    _db.Users.Add(user);
        //    await _db.SaveChangesAsync();

        //    return new UserDto
        //    {
        //        Token = _tokenService.CreateToken(user),
        //        UserName = registerDto.UserName,
        //    };
        //}

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns>UserDto</returns>
        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto) {
            
            try
            {
                var validationResult = _loginService.Login(loginDto);
                if (validationResult != null)
                {
                    return Ok(validationResult);
                }
                return Unauthorized("Invalid Credentials");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Unauthorized(new { ErrorMessage = e.Message});
            }

        }

    }
}
