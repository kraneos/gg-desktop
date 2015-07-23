using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IVehicleTypeService
    {
        IEnumerable<VehicleTypeDto> GetAll();
        VehicleTypeDto Get(string vehicleTypeId);
        void Save(VehicleTypeDto vType);

        void Delete(string Id);
        bool ExistName(string name);
    }
}
