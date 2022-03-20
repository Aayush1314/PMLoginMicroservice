using LoginMicroservice.DTO;
using LoginMicroservice.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
            return _accountRepo.CheckCredentials(loginDto);
        }
    }
}
