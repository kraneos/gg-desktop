using Seggu.Daos.Interfaces;
using Seggu.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Seggu.Daos
{
    public sealed class LocalityDao : GenericDao<Locality>, ILocalityDao
    {
        public IEnumerable<Locality> GetByDistrictId(Guid districId)
        {
            return 
                this.Set.OrderBy(l => l.Name).Where(x => x.DistrictId == districId);
        }
    }
}
