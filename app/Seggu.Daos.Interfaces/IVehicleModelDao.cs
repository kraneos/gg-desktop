using Seggu.Domain;

namespace Seggu.Daos.Interfaces
{
    public interface IVehicleModelDao : IGenericDao<VehicleModel>
    {
        bool GetByName(string name);
    }
}
