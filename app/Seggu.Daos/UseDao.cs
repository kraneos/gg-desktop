using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class UseDao : IdParseEntityDao<Use>, IUseDao
    {
        public UseDao()
            : base()
        {

        }

        public bool GetByName(string name)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Uses.Any(c => c.Name == name);
            }
        }

        public List<Use> GetByVehicleType(int vehicleTypeId)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var vehicleType = context.VehicleTypes.Find(vehicleTypeId);
                return vehicleType.Uses.ToList();
            }
        }

        public void SaveChanges(VehicleType vehicleType, List<Use> existing)
        {
            using (var context = SegguDataModelContext.Create())
            {
                vehicleType = context.VehicleTypes.Find(vehicleType.Id);
                foreach (var obj in existing.Where(obj => !vehicleType.Uses.Contains(obj)))
                {
                    vehicleType.Uses.Add(obj);
                }

                var nonExisting = vehicleType.Uses.Where(u => existing.All(x => x.Id != u.Id));
                while (nonExisting.Any())
                {
                    vehicleType.Uses.Remove(nonExisting.First());
                }

                context.SaveChanges();
            }
        }

        public override void Update(Use obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Uses.Find(obj.Id);
                Mapper.Map<Use, Use>(obj, orig);
                context.SaveChanges();
            }
        }
    }
}
