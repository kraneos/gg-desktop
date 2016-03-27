using Seggu.Domain;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IBodyworkDao : IParseIdEntityDao<Bodywork>
    {
        bool GetByName(string name);

        IEnumerable<Bodywork> GetByVehicleType(int vehicleTypeId);

        void SaveChanges(VehicleType vehicleType, IEnumerable<Bodywork> bodyworks);
    }
}
