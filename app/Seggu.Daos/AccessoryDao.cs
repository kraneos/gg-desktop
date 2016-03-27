using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class AccessoryDao: IdParseEntityDao<Accessory>, IAccessoryDao
    {
        public AccessoryDao(SegguDataModelContext context)
            : base(context)
        {
        }

        public IEnumerable<Accessory> GetByVehicleId(long id)
        {
            return this.Set
                .Where(x => x.VehicleId == id);
        }
    }
}
