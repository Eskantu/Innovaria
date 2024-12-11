using Innovaria.COMMON.Entities;
using Innovaria.COMMON.Interfaces;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovaria.DAL.Repositories.Sensores
{
    public class SensorRepository : ISensorRepository
    {
        private IGenericRepository repository;
        private IPropertiesRepository properties;
        public SensorRepository(IConfiguration configuration, IPropertiesRepository properties)
        {
            repository = new GenericRepository(configuration);
            this.properties = properties;
        }

        public bool AddSensor(string name) => repository.ExecuteStoreProcedure("AddSensor", new List<(string, System.Data.SqlDbType, object)>
        {
            ("@name",SqlDbType.VarChar,name)
        });

        public List<Sensor> GetSensorsByPage(int page) => repository.ExecuteStoreProcedureToList<Sensor>("GetSensoresByPage", new List<(string, SqlDbType, object)>
        {
            ("@skip",SqlDbType.Int,(int.Parse(properties.GetProperty("ItemsByPage").value) * (page-1)))
        });

    }
}
