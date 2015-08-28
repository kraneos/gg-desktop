using Seggu.Domain;
using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IDistrictDao : IGenericDao<District>
    {
        IEnumerable<District> GetByProvince(int provinceId);
    }
}
