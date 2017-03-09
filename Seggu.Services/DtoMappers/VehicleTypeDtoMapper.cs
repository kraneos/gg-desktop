﻿using System;
using Seggu.Domain;
using Seggu.Dtos;

namespace Seggu.Services.DtoMappers
{
    public static class VehicleTypeDtoMapper
    {
        public static VehicleTypeDto GetDto(VehicleType vt)
        {
            var dto = new VehicleTypeDto();
            dto.Id = (int)vt.Id;
            dto.Name = vt.Name;
            return dto;
        }

        public static VehicleType GetObject(VehicleTypeDto VehicleType)
        {
            var b = new VehicleType();
            b.Id = VehicleType.Id;
            b.Name = VehicleType.Name;
            return b;
        }
    }
}
