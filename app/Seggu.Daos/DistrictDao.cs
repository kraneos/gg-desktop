using Seggu.Daos.Interfaces;
using Seggu.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class DistrictDao : GenericDao<District>, IDistrictDao
    {
        public IEnumerable<District> GetByProvince(Guid provinceId)
        {
            return this.container.Districts.Where(x => x.ProvinceId == provinceId);
        }  
    }
}
