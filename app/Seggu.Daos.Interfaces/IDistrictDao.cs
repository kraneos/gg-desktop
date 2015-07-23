using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IDistrictDao : IGenericDao<District>
    {
        IEnumerable<District> GetByProvince(Guid provinceId);
    }
}
