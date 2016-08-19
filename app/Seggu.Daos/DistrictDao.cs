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

        public IEnumerable<District> GetByProvince(long provinceId)
        {
            return this.context.Districts.Where(x => x.ProvinceId == provinceId);
        }

        public override void Update(District obj)
        {
        }
    }
}
