using Seggu.Daos.Interfaces;
using Seggu.Data;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class VehicleTypeDao: GenericDao<VehicleType>, IVehicleTypeDao
    {
        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }
    }
}
