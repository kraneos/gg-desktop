using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class VehicleTypeDao: IdParseEntityDao<VehicleType>, IVehicleTypeDao
    {
        public VehicleTypeDao()
            : base()
        {
        }

        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }

        public override void Update(VehicleType obj)
        {
            var orig = context.VehicleTypes.Find(obj.Id);
            Mapper.Map<VehicleType, VehicleType>(obj, orig);
            context.SaveChanges();
        }
    }
}
