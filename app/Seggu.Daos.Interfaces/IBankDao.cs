using Seggu.Data;

namespace Seggu.Daos.Interfaces
{
    public interface IBankDao : IGenericDao<Bank>
    {
        bool GetByName(string name);
        bool GetByNumber(string number);
    }
}
