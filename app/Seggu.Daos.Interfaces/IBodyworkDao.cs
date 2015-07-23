using Seggu.Data;

namespace Seggu.Daos.Interfaces
{
    public interface IBodyworkDao : IGenericDao<Bodywork>
    {
        bool GetByName(string name);
    }
}
