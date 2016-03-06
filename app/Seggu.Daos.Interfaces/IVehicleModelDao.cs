using Seggu.Domain;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IVehicleModelDao : IParseIdEntityDao<VehicleModel>
    {
        bool GetByName(string name);

        IEnumerable<VehicleModel> GetWithReferences();
    }
}
