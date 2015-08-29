using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface IUseDao : IIdEntityDao<Use>
    {
        bool GetByName(string name);
    }
}
