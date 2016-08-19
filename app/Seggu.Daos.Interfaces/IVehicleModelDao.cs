using Seggu.Domain;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IVehicleModelDao : IParseIdEntityDao<VehicleModel>
    {
        bool GetByName(string name);

        List<VehicleModel> GetWithReferences();
        bool ExistsByBrand(int brandId);
    }
}
