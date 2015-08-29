using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class AccessoryDao: IdEntityDao<Accessory>, IAccessoryDao
    {
        public IEnumerable<Accessory> GetByVehicleId(long id)
        {
            return this.Set
                .Where(x => x.VehicleId == id);
        }
    }
}
