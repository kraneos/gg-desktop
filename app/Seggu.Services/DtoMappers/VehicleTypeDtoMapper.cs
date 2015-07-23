using System;
using Seggu.Data;
using Seggu.Dtos;

namespace Seggu.Services.DtoMappers
{
    public static class VehicleTypeDtoMapper
    {
        public static VehicleTypeDto GetDto(Data.VehicleType vt)
        {
            var dto = new VehicleTypeDto();
            dto.Id = vt.Id.ToString();
            dto.Name = vt.Name;
            return dto;
        }

        public static Data.VehicleType GetObject(VehicleTypeDto VehicleType)
        {
            var b = new VehicleType();
            b.Id = new Guid(VehicleType.Id);
            b.Name = VehicleType.Name;
            return b;
        }
    }
}
