using Seggu.Dtos;
using System.Collections.Generic;


namespace Seggu.Services.Interfaces
{
    public interface IUseService
    {
        IEnumerable<UseDto> GetAll();
        void Save(UseDto bank);
        void Update(UseDto bank);
        void Delete(int id);
        bool ExistName(string name);
        IEnumerable<UseDto> GetByVehicleType(int vehicleTypeId);
        void SaveChanges(VehicleTypeDto vehicleTypeDto, IEnumerable<UseDto> existing);
    }
}
