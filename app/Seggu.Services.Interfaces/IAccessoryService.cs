using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IAccessoryService
    {
        IEnumerable<AccessoryDto> GetByVehicleId(int Id);
        void Save(AccessoryDto dto);
    }
}
