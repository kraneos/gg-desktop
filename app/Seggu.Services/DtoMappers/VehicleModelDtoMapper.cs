using Seggu.Data;
using Seggu.Dtos;
using Seggu.Helpers;
using System.Linq;
using System;

namespace Seggu.Services.DtoMappers
{
    public static class VehicleModelDtoMapper
    {
        public static VehicleModelDto GetDto(VehicleModel obj)
        {
            var dto = new VehicleModelDto();
            dto.Id = obj.Id.ToString();
            dto.Name = obj.Name;
            dto.BrandId = obj.BrandId.ToString();
            dto.Origin = OriginDtoMapper.ToString(obj.Origin);
            dto.VehicleTypeId = obj.VehicleTypeId.ToString();
            dto.Bodyworks = obj.VehicleType.Bodyworks
                .OrderBy(b => b.Name).Select(bw => BodyworkDtoMapper.GetDto(bw)).ToList();
            dto.Uses = obj.VehicleType.Uses
                .OrderBy(u => u.Name).Select(u => UseDtoMapper.GetDto(u)).ToList();
            return dto;
        }

        public static VehicleModel GetObject(VehicleModelDto dto)
        {
            var obj = new VehicleModel();
            obj.BrandId = new Guid(dto.BrandId);
            obj.Id = string.IsNullOrEmpty(dto.Id) ? Guid.Empty : new Guid(dto.Id);
            obj.Name = dto.Name;
            obj.Origin = OriginDtoMapper.ToEnum(dto.Origin);
            obj.VehicleTypeId = new Guid(dto.VehicleTypeId);
            return obj;
        }

    }
}
