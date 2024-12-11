using Innovaria.COMMON.Entities;
using Innovaria.COMMON.Interfaces;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Innovaria.DAL.Repositories.Properties
{
    public class PropertiesRepository : IPropertiesRepository
    {
        private readonly IGenericRepository _genericRepository;
        public PropertiesRepository(IConfiguration configuration)
        {
            _genericRepository = new GenericRepository(configuration);
        }
        public Property GetProperty(string propertyName)
        {
            List<Property> properties = _genericRepository.ExecuteStoreProcedureToList<Property>("GetPropertyByPropertyName", new List<(string, System.Data.SqlDbType, object)>()
        {
            ("@Propertyname",System.Data.SqlDbType.VarChar,propertyName)
        });
            return properties.Count > 0 ? properties[0] : new Property();
        }
    }
}
