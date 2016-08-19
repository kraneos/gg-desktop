using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class VehicleModelDao : IdParseEntityDao<VehicleModel>, IVehicleModelDao
    {
        public VehicleModelDao()
            : base()
        {

        }

        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }

        public IEnumerable<VehicleModel> GetWithReferences()
        {
            return this.Set.Include("Brand").Include("VehicleType");
        }

        public override void Update(VehicleModel obj)
        {
            var orig = context.VehicleModels.Find(obj.Id);
            Mapper.Map<VehicleModel, VehicleModel>(obj, orig);
            context.SaveChanges();
        }
    }
}
