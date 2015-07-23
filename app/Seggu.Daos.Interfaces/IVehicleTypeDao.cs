using Seggu.Data;

namespace Seggu.Daos.Interfaces
{
    public interface IVehicleTypeDao : IGenericDao<VehicleType>
    {
        bool GetByName(string name);
    }
}
