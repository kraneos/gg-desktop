using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface IBrandDao : IParseIdEntityDao<Brand>
    {
        bool GetByName(string name);
    }
}
