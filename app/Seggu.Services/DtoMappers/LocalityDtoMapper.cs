using Seggu.Domain;
using Seggu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.DtoMappers
{
    public static class LocalityDtoMapper
    {
        public static LocalityDto GetDto(Locality loc)
        {
            var l = new LocalityDto();
            l.Id = loc.Id;
            l.Name = loc.Name;
            l.DistrictId = loc.DistrictId;
            return l;
        }
    }
}
