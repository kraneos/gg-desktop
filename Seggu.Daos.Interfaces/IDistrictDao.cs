using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IDistrictDao : IParseIdEntityDao<District>
    {
        IEnumerable<District> GetByProvince(long provinceId);
    }
}
