using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class VehicleModelDao : GenericDao<VehicleModel>, IVehicleModelDao
    {
        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }
    }
}
