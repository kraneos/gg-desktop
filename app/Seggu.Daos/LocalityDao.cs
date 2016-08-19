using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class LocalityDao : IdParseEntityDao<Locality>, ILocalityDao
    {
        public LocalityDao()
            : base()
        {

        }

        public List<Locality> GetByDistrictId(long districId)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return
                    context.Localities.OrderBy(l => l.Name).Where(x => x.DistrictId == districId).ToList();
            }
        }

        public override void Update(Locality obj)
        {
            //localidades no son editables
        }
    }
}
