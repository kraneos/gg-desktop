using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class VehicleModelDao : IdEntityDao<VehicleModel>, IVehicleModelDao
    {
        public VehicleModelDao(SegguDataModelContext context)
            : base(context)
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
    }
}
