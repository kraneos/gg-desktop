using Seggu.Dtos;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.DtoMappers
{
    public class DistrictDtoMapper
    {
        public static DistrictDto GetDto(District d)
        {
            var district = new DistrictDto();
            district.Id = (int)d.Id;
            district.Name = d.Name;
            district.ProvinceId = (int)d.ProvinceId;
            return district;
        }
    }
}
