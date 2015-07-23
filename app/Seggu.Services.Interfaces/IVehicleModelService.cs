using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IVehicleModelService
    {
        IEnumerable<VehicleModelDto> GetAll();
        IEnumerable<VehicleModelDto> GetByBrand(string brandId);
        void Save(VehicleModelDto model);
        void Delete(VehicleModelDto model);
        void Delete(string id);
        bool ExistName(string name);
    }
}
