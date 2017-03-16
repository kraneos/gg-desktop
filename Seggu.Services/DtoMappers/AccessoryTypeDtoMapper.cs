using Seggu.Domain;
using Seggu.Dtos;
using System;

namespace Seggu.Services.DtoMappers
{
    public static class AccessoryTypeDtoMapper
    {
        public static AccessoryTypeDto GetDto(AccessoryType obj)
        {
            var dto = new AccessoryTypeDto();
            dto.Id = (int)obj.Id;
            dto.Name = obj.Name;
            return dto;
        }

        public static AccessoryType GetObject(AccessoryTypeDto dto)
        {
            var obj = new AccessoryType();
            obj.Id = dto.Id;
            obj.Name = dto.Name;
            return obj;
        }
    }
}
