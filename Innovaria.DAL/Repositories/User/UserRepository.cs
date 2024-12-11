using Innovaria.COMMON.Entities;
using Innovaria.COMMON.Interfaces;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovaria.DAL.Repositories.NewFolder
{
    public class UserRepository : IUserRepository
    {
        private GenericRepository repository;
        public UserRepository(IConfiguration configuration)
        {
            repository = new GenericRepository(configuration);
        }

        public User GetUser(string username)
        {
            var users = repository.ExecuteStoreProcedureToList<User>("GetuserByUsername", new List<(string, System.Data.SqlDbType, object)> { new("@UserName", System.Data.SqlDbType.VarChar, username) });

            return users.Count > 0 ? users[0] : new User() { LastName = "", Name = "", Password = "", UserName = "" };
        }

        public List<User> GetUsers()
        {
            return repository.ExecuteStoreProcedureToList<User>("GetAllUser");
        }

        public bool AddUser(User user)
        => repository.ExecuteStoreProcedure("AddUser", new List<(string, System.Data.SqlDbType, object)>
            {
                new ("@userName", System.Data.SqlDbType.VarChar, user.UserName),
                new ("@password", System.Data.SqlDbType.VarChar, user.Password),
                new ("@name", System.Data.SqlDbType.VarChar, user.Name),
                new ("@lastName", System.Data.SqlDbType.VarChar, user.LastName),
            });

    }
}
