using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class AccessoryDao : IdParseEntityDao<Accessory>, IAccessoryDao
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

        public override void Update(Accessory obj)
        {
            // Update  ields
            var orig = context.Accessories.Find(obj.Id);
            orig.Name = obj.Name;
            orig.Stamp = obj.Stamp;
            orig.Value = obj.Value;
            orig.ExpirationDate = obj.ExpirationDate;
        }
    }
}
