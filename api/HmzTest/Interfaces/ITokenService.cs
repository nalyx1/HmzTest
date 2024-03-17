using HmzTest.Models;

namespace HmzTest.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(UserModel userModel);
    }
}
