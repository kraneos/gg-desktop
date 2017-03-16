using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IAccessoryTypeService
    {
        IEnumerable<AccessoryTypeDto> GetAll();
    }
}
