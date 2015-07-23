using Seggu.Dtos;
using System.Collections.Generic;
using System;

namespace Seggu.Services.Interfaces
{
    public interface ILocalityService
    {
        IEnumerable<LocalityDto> GetByDistrictId(string districtId);
        IEnumerable<LocalityDto> GetAll();
    }
}
