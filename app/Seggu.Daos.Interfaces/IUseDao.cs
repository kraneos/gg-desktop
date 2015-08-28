using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface IUseDao : IGenericDao<Use>
    {
        bool GetByName(string name);
    }
}
