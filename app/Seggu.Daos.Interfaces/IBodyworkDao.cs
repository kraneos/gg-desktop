using Seggu.Domain;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IBodyworkDao : IParseIdEntityDao<Bodywork>
    {
        bool GetByName(string name);

        List<Bodywork> GetByVehicleType(int vehicleTypeId);

        void SaveChanges(VehicleType vehicleType, List<Bodywork> bodyworks);
    }
}
