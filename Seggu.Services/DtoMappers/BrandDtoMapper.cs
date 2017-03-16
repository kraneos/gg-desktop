using Seggu.Domain;
using Seggu.Dtos;
using System;

namespace Seggu.Services.DtoMappers
{
    public static class BrandDtoMapper
    {
        public static BrandDto GetDto(Brand b)
        {
            var dto = new BrandDto();
            dto.Id = (int)b.Id;
            dto.Name = b.Name;
            return dto;
        }

        public static Brand GetObject(BrandDto brand)
        {
            var b = new Brand();
            b.Id = brand.Id;
            b.Name = brand.Name;
            return b;
        }
    }
}