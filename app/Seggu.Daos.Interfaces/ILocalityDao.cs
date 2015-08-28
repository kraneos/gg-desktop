using Seggu.Domain;
using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ILocalityDao : IGenericDao<Locality>
    {
        IEnumerable<Locality> GetByDistrictId(int districId);
    }
}
