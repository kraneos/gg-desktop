using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface ICasualtyTypeService
    {
        IEnumerable<CasualtyTypeDto> GetAll();
    }
}
