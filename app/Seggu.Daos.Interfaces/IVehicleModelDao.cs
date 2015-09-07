using Seggu.Domain;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IVehicleModelDao : IIdEntityDao<VehicleModel>
    {
        bool GetByName(string name);

        IEnumerable<VehicleModel> GetWithReferences();
    }
}
