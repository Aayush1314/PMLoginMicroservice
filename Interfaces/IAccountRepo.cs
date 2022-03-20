using LoginMicroservice.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LoginMicroservice.Interfaces
{
    public interface IAccountRepo
    {
        public UserDto CheckCredentials(LoginDto loginDto);

    }
}