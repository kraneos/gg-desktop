using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface IVehicleTypeDao : IParseIdEntityDao<VehicleType>
    {
        bool GetByName(string name);
    }
}
