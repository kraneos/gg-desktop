using Seggu.Dtos;
using Seggu.Data;
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
            district.Id = d.Id.ToString();
            district.Name = d.Name;
            district.ProvinceId = d.ProvinceId.ToString();
            return district;
        }
    }
}
