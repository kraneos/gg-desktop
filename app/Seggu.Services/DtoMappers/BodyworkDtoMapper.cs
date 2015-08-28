using Seggu.Domain;
using Seggu.Dtos;
using System;

namespace Seggu.Services.DtoMappers
{
    public static class BodyworkDtoMapper
    {
        public static BodyworkDto GetDto(Bodywork b)
        {
            var dto = new BodyworkDto();
            dto.Id = b.Id;
            dto.Name = b.Name;
            return dto;
        }
        public static Bodywork GetObject(BodyworkDto dto)
        {
            var obj = new Bodywork();
            obj.Id = dto.Id;
            obj.Name = dto.Name;
            return obj;
        }
    }
}
