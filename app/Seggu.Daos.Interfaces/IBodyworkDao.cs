using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface IBodyworkDao : IIdEntityDao<Bodywork>
    {
        bool GetByName(string name);
    }
}
