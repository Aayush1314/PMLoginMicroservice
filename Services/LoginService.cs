using LoginMicroservice.DTO;
using LoginMicroservice.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LoginMicroservice.Services
{
    public class LoginService : ILoginService
    {
        private readonly IAccountRepo _accountRepo;

        public LoginService(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public dynamic Login(LoginDto loginDto)
        {
            try
            {
                Console.WriteLine("asdsadsadas");
                var res = _accountRepo.CheckCredentials(loginDto);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
               // return null;
            }
        }
    }
}
