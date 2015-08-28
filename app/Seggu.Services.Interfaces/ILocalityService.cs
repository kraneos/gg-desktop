using Seggu.Dtos;
using System.Collections.Generic;
using System;

namespace Seggu.Services.Interfaces
{
    public interface ILocalityService
    {
        IEnumerable<LocalityDto> GetByDistrictId(int districtId);
        IEnumerable<LocalityDto> GetAll();
    }
}
