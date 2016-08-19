using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class BodyworkDao : IdParseEntityDao<Bodywork>, IBodyworkDao
    {
        public BodyworkDao()
            : base()
        {
        }

        public bool GetByName(string name)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Bodyworks.Any(c => c.Name == name); 
            }
        }

        public IEnumerable<Bodywork> GetByVehicleType(int vehicleTypeId)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.VehicleTypes.Find(vehicleTypeId).Bodyworks;
            }
        }

        public void SaveChanges(VehicleType vehicleType, IEnumerable<Bodywork> existing)
        {
            using (var context = SegguDataModelContext.Create())
            {
                vehicleType = context.VehicleTypes.Find(vehicleType.Id);

                foreach (var obj in existing)
                {
                    if (!vehicleType.Bodyworks.Any(x => x.Id == obj.Id))
                    {
                        vehicleType.Bodyworks.Add(obj);
                    }
                }

                var nonExisting = vehicleType.Bodyworks.Where(b => !existing.Any(x => x.Id == b.Id));
                while (nonExisting.Any())
                {
                    vehicleType.Bodyworks.Remove(nonExisting.First());
                }

                context.SaveChanges(); 
            }
        }

        public override void Update(Bodywork obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Bodyworks.Find(obj.Id);
                Mapper.Map<Bodywork, Bodywork>(obj, orig);
                context.SaveChanges(); 
            }
        }
    }
}
