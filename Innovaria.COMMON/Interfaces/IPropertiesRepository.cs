using Innovaria.COMMON.Entities;

namespace Innovaria.COMMON.Interfaces
{
    public interface IPropertiesRepository
    {
        Property GetProperty(string propertyName);
    }
}