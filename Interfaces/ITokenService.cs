using LoginMicroservice.Model;

namespace LoginMicroservice.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
