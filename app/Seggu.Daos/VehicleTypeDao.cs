using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class VehicleTypeDao: IdEntityDao<VehicleType>, IVehicleTypeDao
    {
        public VehicleTypeDao(SegguDataModelContext context)
            : base(context)
        {
        }

        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }
    }
}
