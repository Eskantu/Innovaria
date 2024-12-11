using Innovaria.COMMON.Entities;
using Innovaria.COMMON.Interfaces;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovaria.DAL.Repositories.Lecturas
{
    public class LecturasRepository : ILecturasRepository
    {
        private IGenericRepository repository;
        private IPropertiesRepository properties;
        public LecturasRepository(IConfiguration configuration, IPropertiesRepository properties)
        {
            repository = new GenericRepository(configuration);
            this.properties = properties;
        }

        public bool AddLectura(COMMON.Entities.Lecturas lecturas) => repository.ExecuteStoreProcedure("AddLectura", new List<(string, System.Data.SqlDbType, object)>
        {
            new ("@PkSensor", System.Data.SqlDbType.Int, lecturas.FkSensor),
            new ("@Value", System.Data.SqlDbType.Int, lecturas.Value)
        });

        public List<COMMON.Entities.Lecturas> GetLecturasByPage(int page) => repository.ExecuteStoreProcedureToList<COMMON.Entities.Lecturas>("GetLecturasByPage", new List<(string, System.Data.SqlDbType, object)>
        {
            ("@skip",SqlDbType.Int,(int.Parse(properties.GetProperty("ItemsByPage").value) * (page-1)))
        });
    }
}
