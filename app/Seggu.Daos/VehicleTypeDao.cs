using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class VehicleTypeDao : IdParseEntityDao<VehicleType>, IVehicleTypeDao
    {
        public VehicleTypeDao()
            : base()
        {
        }

        public bool GetByName(string name)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.VehicleTypes.Any(c => c.Name == name);
            }
        }

        public override void Update(VehicleType obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.VehicleTypes.Find(obj.Id);
                Mapper.Map<VehicleType, VehicleType>(obj, orig);
                context.SaveChanges();
            }
        }
    }
}
