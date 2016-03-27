using Seggu.Domain;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IUseDao : IParseIdEntityDao<Use>
    {
        bool GetByName(string name);

        IEnumerable<Use> GetByVehicleType(int vehicleTypeId);

        void SaveChanges(VehicleType vehicleType, IEnumerable<Use> existing);

    }
}
