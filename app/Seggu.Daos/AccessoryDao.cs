using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class AccessoryDao : IdParseEntityDao<Accessory>, IAccessoryDao
    {
        public AccessoryDao()
            : base()
        {
        }

        public List<Accessory> GetByVehicleId(long id)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Accessories
                        .Where(x => x.VehicleId == id).ToList(); 
            }
        }

        public override void Update(Accessory obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Accessories.Find(obj.Id);
                Mapper.Map<Accessory, Accessory>(obj, orig);
                context.SaveChanges(); 
            }
        }
    }
}
