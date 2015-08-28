using Seggu.Domain;
using Seggu.Dtos;
using System;

namespace Seggu.Services.DtoMappers
{
    public static class UseDtoMapper
    {
        public static UseDto GetDto(Use b)
        {
            var dto = new UseDto();
            dto.Id = b.Id;
            dto.Name = b.Name;
            return dto;
        }

        public static Use GetUse(UseDto dto)
        {
            var use = new Use();

            use.Name = dto.Name;
            return use;
        }
    }
}
