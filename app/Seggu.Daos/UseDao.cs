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
            return this.Set.Any(c => c.Name == name);
        }

        public IEnumerable<Use> GetByVehicleType(int vehicleTypeId)
        {
            var vehicleType = this.context.VehicleTypes.Find(vehicleTypeId);
            return vehicleType.Uses;
        }

        public void SaveChanges(VehicleType vehicleType, IEnumerable<Use> existing)
        {
            vehicleType = this.context.VehicleTypes.Find(vehicleType.Id);
            foreach (var obj in existing)
            {
                if (!vehicleType.Uses.Contains(obj))
                {
                    vehicleType.Uses.Add(obj);
                }
            }

            var nonExisting = vehicleType.Uses.Where(u => !existing.Any(x => x.Id == u.Id));
            while (nonExisting.Any())
            {
                vehicleType.Uses.Remove(nonExisting.First());
            }

            this.context.SaveChanges();
        }

        public override void Update(Use obj)
        {
            var orig = context.Uses.Find(obj.Id);
            Mapper.Map<Use, Use>(obj, orig);
            context.SaveChanges();
        }
    }
}
