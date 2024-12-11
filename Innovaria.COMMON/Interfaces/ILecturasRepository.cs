namespace Innovaria.COMMON.Interfaces
{
    public interface ILecturasRepository
    {
        bool AddLectura(COMMON.Entities.Lecturas lecturas);
        List<COMMON.Entities.Lecturas> GetLecturasByPage(int page);
    }
}