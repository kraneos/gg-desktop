using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface IBrandDao : IIdEntityDao<Brand>
    {
        bool GetByName(string name);
    }
}
