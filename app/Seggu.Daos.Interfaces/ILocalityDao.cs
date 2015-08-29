using Seggu.Domain;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ILocalityDao : IIdEntityDao<Locality>
    {
        IEnumerable<Locality> GetByDistrictId(long districId);
    }
}
