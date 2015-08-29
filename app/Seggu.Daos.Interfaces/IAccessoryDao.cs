using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IAccessoryDao : IIdEntityDao<Accessory>
    {
        IEnumerable<Accessory> GetByVehicleId(long id);
    }
}
