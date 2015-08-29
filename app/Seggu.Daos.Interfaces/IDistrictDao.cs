using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IDistrictDao : IIdEntityDao<District>
    {
        IEnumerable<District> GetByProvince(long provinceId);
    }
}
