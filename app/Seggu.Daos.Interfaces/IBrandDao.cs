using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface IBrandDao : IGenericDao<Brand>
    {
        bool GetByName(string name);
    }
}
