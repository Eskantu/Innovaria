using Examen.Core.DAL;

using Innovaria.COMMON.Interfaces;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Innovaria.DAL
{
    public class GenericRepository : IGenericRepository
    {
        private string connectionString;
        public GenericRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("Connection string not found");
        }
        public List<T> ExecuteStoreProcedureToList<T>(string spName, List<(string, SqlDbType, object)> parameters) where T : class
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string paramtersName = string.Join(" ,", parameters.Select(t => t.Item1));
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandText = $"{spName} {paramtersName}";

                parameters.ForEach(parameter =>
                {
                    sqlCommand.Parameters.Add(parameter.Item1, parameter.Item2).Value = parameter.Item3;
                });
                return sqlCommand.ExecuteReader().Select(r => CrearEntidad<T>(r, typeof(T))).ToList();

            }
        }

        public List<T> ExecuteStoreProcedureToList<T>(string spName) where T : class
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandText = spName;
                conn.Open();
                return sqlCommand.ExecuteReader().Select(r => CrearEntidad<T>(r, typeof(T))).ToList();

            }
        }

        public bool ExecuteStoreProcedure(string spName, List<(string, SqlDbType, object)> parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string paramtersName = string.Join(" ,", parameters.Select(t => t.Item1));
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandText = $"{spName} {paramtersName}";

                parameters.ForEach(parameter =>
                {
                    sqlCommand.Parameters.Add(parameter.Item1, parameter.Item2).Value = parameter.Item3;
                });
                sqlCommand.ExecuteNonQuery();

            }
            return true;
        }

        public bool ExecuteStoreProcedure(string spName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandText = $"{spName}";
                sqlCommand.ExecuteNonQuery();

            }
            return true;
        }

        private T CrearEntidad<T>(IDataReader data, Type tipoDato) where T : class
        {
            T entidad;
            PropertyInfo[] properties = tipoDato.GetProperties();
            entidad = (T)Activator.CreateInstance(tipoDato)!;
            properties.ToList().ForEach(property =>
            {
                property.SetValue(entidad, data[property.Name] == DBNull.Value ? null : data[property.Name]);
            });
            return entidad;
        }
    }
}
