using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IAccessoryService
    {
        IEnumerable<AccessoryDto> GetByVehicleId(string Id);
        void Save(AccessoryDto dto);
    }
}
