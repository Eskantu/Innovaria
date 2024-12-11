using System.Data;

namespace Innovaria.COMMON.Interfaces
{
    public interface IGenericRepository
    {
        bool ExecuteStoreProcedure(string spName, List<(string, SqlDbType, object)> parameters);
        List<T> ExecuteStoreProcedureToList<T>(string spName, List<(string, SqlDbType, object)> parameters) where T : class;

        bool ExecuteStoreProcedure(string spName);
        List<T> ExecuteStoreProcedureToList<T>(string spName) where T : class;
    }
}