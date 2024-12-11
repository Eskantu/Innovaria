using Innovaria.COMMON.Entities;

namespace Innovaria.COMMON.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User userLogin);
    }
}