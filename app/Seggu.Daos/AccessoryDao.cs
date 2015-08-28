using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class AccessoryDao: GenericDao<Accessory>, IAccessoryDao
    {
        public IEnumerable<Accessory> GetByVehicleId(int id)
        {
            return this.Set
                .Where(x => x.VehicleId == id);
        }
    }
}
