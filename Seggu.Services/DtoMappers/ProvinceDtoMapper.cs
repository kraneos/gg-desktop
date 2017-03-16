using Seggu.Domain;
using Seggu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.DtoMappers
{
    public static class ProvinceDtoMapper
    {
        public static ProvinceDto GetDto(Province p)
        {
            var prov = new ProvinceDto();
            prov.Id = (int)p.Id;
            prov.Name = p.Name;
            return prov;
        }
    }
}
