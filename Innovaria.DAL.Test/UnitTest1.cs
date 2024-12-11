

using Innovaria.COMMON.Entities;
using Innovaria.COMMON.Interfaces;

using Microsoft.Extensions.Configuration;

using System.Configuration;

namespace Innovaria.DAL.Test
{
    public class Tests
    {
        private IGenericRepository repository;

        [SetUp]
        public void Setup()
        {
            var myConfiguration = new Dictionary<string, string>
            {
                {"ConnectionStrings:DefaultConnection", "Server=(localdb)\\MSSQLLocalDB;Database=Innovaria;Integrated Security=true;"},
            };
           var configuration = new ConfigurationBuilder()
                 .AddInMemoryCollection(myConfiguration)
                 .Build();
            repository = new GenericRepository(configuration);
        }

        [Test]
        public void InsertIntoTable()
        {
            Assert.IsTrue(repository.ExecuteStoreProcedure("AddUser", new List<(string, System.Data.SqlDbType, object)>
            {
                new ("@userName", System.Data.SqlDbType.VarChar, "eskantu"),
                new ("@password", System.Data.SqlDbType.VarChar, "qwerty123"),
                new ("@name", System.Data.SqlDbType.VarChar, "mario"),
                new ("@lastName", System.Data.SqlDbType.VarChar, "escalante"),
            }));
        }

        [Test]
        public void GetFromTable()
        {
            Assert.Greater(repository.ExecuteStoreProcedureToList<User>("GetAllUser").Count, 0);
        }

        [Test]
        public void DeleteFromTable()
        {
            int pkUser = repository.ExecuteStoreProcedureToList<User>("GetAllUser")[0].PkUser;
            Assert.IsTrue(repository.ExecuteStoreProcedure("DeleteUser", new List<(string, System.Data.SqlDbType, object)>
            {
                new ("@PkUser",System.Data.SqlDbType.Int,pkUser)
            }));
        }
    }
}