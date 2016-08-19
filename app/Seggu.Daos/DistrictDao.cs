using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class DistrictDao : IdParseEntityDao<District>, IDistrictDao
    {
        public DistrictDao()
            : base()
        {

        }

        public List<District> GetByProvince(long provinceId)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Districts.Where(x => x.ProvinceId == provinceId).ToList();
            }
        }

        public override void Update(District obj)
        {
        }
    }
}
