using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IVehicleTypeService
    {
        IEnumerable<VehicleTypeDto> GetAll();
        VehicleTypeDto Get(int vehicleTypeId);
        void Save(VehicleTypeDto vType);

        void Delete(int Id);
        bool ExistName(string name);
    }
}
