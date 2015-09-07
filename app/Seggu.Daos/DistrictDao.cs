using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class DistrictDao : IdEntityDao<District>, IDistrictDao
    {
        public DistrictDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public IEnumerable<District> GetByProvince(long provinceId)
        {
            return this.context.Districts.Where(x => x.ProvinceId == provinceId);
        }  
    }
}
