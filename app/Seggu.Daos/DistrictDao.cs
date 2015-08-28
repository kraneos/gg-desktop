using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class DistrictDao : GenericDao<District>, IDistrictDao
    {
        public IEnumerable<District> GetByProvince(int provinceId)
        {
            return this.container.Districts.Where(x => x.ProvinceId == provinceId);
        }  
    }
}
