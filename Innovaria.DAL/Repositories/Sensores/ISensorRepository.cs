using Innovaria.COMMON.Entities;

namespace Innovaria.DAL.Repositories.Sensores
{
    public interface ISensorRepository
    {
        bool AddSensor(string name);
        List<Sensor> GetSensorsByPage(int page);
    }
}