using Seggu.Domain;
using Seggu.Dtos;
using System;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class AssetDtoMapper
    {
        public static AssetDto GetDto(Asset asset)
        {
            var dto = new AssetDto();
            dto.Id = (int)asset.Id;
            dto.Name = asset.Name;
            dto.Amount = asset.Amount;
            return dto;
        }

        public static Asset GetObject(AssetDto asset)
        {
            var c = new Asset();
            c.Id = asset.Id; 
            c.Name = asset.Name;
            c.Amount = asset.Amount;
            return c;
        }
    }
}
