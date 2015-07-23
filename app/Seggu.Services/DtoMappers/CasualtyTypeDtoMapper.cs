using Seggu.Data;
using Seggu.Dtos;
using System;

namespace Seggu.Services.DtoMappers
{
    public static class CasualtyTypeDtoMapper
    {
        public static CasualtyTypeDto GetDto(CasualtyType obj)
        {
            var dto = new CasualtyTypeDto();
            dto.Id = obj.Id.ToString();
            dto.Name = obj.Name;
            return dto;
        }

        public static CasualtyType GetObject(CasualtyTypeDto dto)
        {
            var obj = new CasualtyType();
            obj.Id = new Guid(dto.Id);
            obj.Name = dto.Name;
            return obj;
        }
    }
}
