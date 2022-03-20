using LoginMicroservice.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoginMicroservice.Interfaces
{
    public interface ILoginService
    {
        public dynamic Login(LoginDto loginDto);

    }
}
