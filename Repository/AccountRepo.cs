using LoginMicroservice.Data;
using LoginMicroservice.DTO;
using LoginMicroservice.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;
using Microsoft.Extensions.Configuration;

namespace LoginMicroservice.Repository
{
    public class AccountRepo : IAccountRepo
    {
        private readonly ITokenService _tokenService;
        private readonly ProtfolioDbContext _db;
        private IConfiguration _config;
        public AccountRepo(IConfiguration config,ITokenService tokenService,ProtfolioDbContext db)
        {
            _tokenService = tokenService;
            _db = db;
            _config = config;
        }

        public UserDto CheckCredentials(LoginDto loginDto)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == loginDto.UserName);
            if (user == null)
            {
                return null;
            }
            
            try { 
            using var hmac = new HMACSHA512(user.PasswordSalt);                
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return null;
            }

            return new UserDto
            {
                UserId = user.UserId,
                UserName = loginDto.UserName,
                Token = _tokenService.CreateToken(user)
            };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                
            }
            
        }
    }
}
