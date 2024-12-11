using Innovaria.COMMON.Entities;

namespace Innovaria.COMMON.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string username);
        List<User> GetUsers();
        bool AddUser(User user);
    }
}