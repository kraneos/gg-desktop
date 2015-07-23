using Seggu.Data;
using Seggu.Dtos;
using System;

namespace Seggu.Services.DtoMappers
{
    public static class BrandDtoMapper
    {
        public static BrandDto GetDto(Brand b)
        {
            var dto = new BrandDto();
            dto.Id = b.Id.ToString();
            dto.Name = b.Name;
            return dto;
        }

        public static Data.Brand GetObject(BrandDto brand)
        {
            var b = new Brand();
            b.Id = new Guid(brand.Id);
            b.Name = brand.Name;
            return b;
        }
    }
}