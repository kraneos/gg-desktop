using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface IVehicleModelDao : IIdEntityDao<VehicleModel>
    {
        bool GetByName(string name);
    }
}
