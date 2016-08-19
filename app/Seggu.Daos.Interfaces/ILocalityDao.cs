using Seggu.Domain;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ILocalityDao : IParseIdEntityDao<Locality>
    {
        List<Locality> GetByDistrictId(long districId);
    }
}
