using Seggu.Domain;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IClientDao : IIdEntityDao<Client>
    {
        IEnumerable<Client> GetByDni(string search);

        IEnumerable<Client> GetByFullName(string search);
        IEnumerable<Client> GetValids();

    }
}
