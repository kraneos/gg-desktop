using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Seggu.Daos
{
    public sealed class LocalityDao : IdEntityDao<Locality>, ILocalityDao
    {
        public IEnumerable<Locality> GetByDistrictId(long districId)
        {
            return 
                this.Set.OrderBy(l => l.Name).Where(x => x.DistrictId == districId);
        }
    }
}
