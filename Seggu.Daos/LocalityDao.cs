using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class LocalityDao : IdParseEntityDao<Locality>, ILocalityDao
    {
        public LocalityDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public IEnumerable<Locality> GetByDistrictId(long districId)
        {
            return 
                this.Set.OrderBy(l => l.Name).Where(x => x.DistrictId == districId);
        }

        public override void Update(Locality obj)
        {
            //localidades no son editables
        }
    }
}
