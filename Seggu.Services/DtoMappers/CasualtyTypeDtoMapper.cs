using Seggu.Domain;
using Seggu.Dtos;
using System;

namespace Seggu.Services.DtoMappers
{
    public static class CasualtyTypeDtoMapper
    {
        public static CasualtyTypeDto GetDto(CasualtyType obj)
        {
            var dto = new CasualtyTypeDto();
            dto.Id = (int)obj.Id;
            dto.Name = obj.Name;
            return dto;
        }

        public static CasualtyType GetObject(CasualtyTypeDto dto)
        {
            var obj = new CasualtyType();
            obj.Id = dto.Id;
            obj.Name = dto.Name;
            return obj;
        }
    }
}
