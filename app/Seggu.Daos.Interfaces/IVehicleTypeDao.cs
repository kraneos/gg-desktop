using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface IVehicleTypeDao : IIdEntityDao<VehicleType>
    {
        bool GetByName(string name);
    }
}
