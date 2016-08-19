using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IAccessoryDao : IParseIdEntityDao<Accessory>
    {
        List<Accessory> GetByVehicleId(long id);
    }
}
