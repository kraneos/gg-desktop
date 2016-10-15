﻿using Seggu.Domain;
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
            dto.Id = (int)obj.Id;
            dto.Name = obj.Name;
            dto.BrandId = (int)obj.BrandId;
            dto.Origin = OriginDtoMapper.ToString(obj.Origin);
            dto.VehicleTypeId = (int)obj.VehicleTypeId;
            dto.Bodyworks = obj.VehicleType.Bodyworks
                .OrderBy(b => b.Name).Select(bw => BodyworkDtoMapper.GetDto(bw)).ToList();
            dto.Uses = obj.VehicleType.Uses
                .OrderBy(u => u.Name).Select(u => UseDtoMapper.GetDto(u)).ToList();
            return dto;
        }

        public static VehicleModel GetObject(VehicleModelDto dto)
        {
            var obj = new VehicleModel();
            obj.BrandId = dto.BrandId;
            obj.Id = dto.Id;
            obj.Name = dto.Name;
            obj.Origin = OriginDtoMapper.ToEnum(dto.Origin);
            obj.VehicleTypeId = dto.VehicleTypeId;
            return obj;
        }


        public static VehicleModelFullDto GetFullDto(VehicleModel vm)
        {
            var dto = new VehicleModelFullDto();
            dto.Id = (int)vm.Id;
            dto.Name = vm.Name;
            dto.BrandName = vm.Brand.Name;
            dto.VehicleTypeName = vm.VehicleType.Name;
            switch (vm.Origin)
            {
                case Origin.National:
                    dto.Origin = "Nacional";
                    break;
                case Origin.Imported:
                    dto.Origin = "Importado";
                    break;
                default:
                    dto.Origin = "Desconocido";
                    break;
            }
            return dto;
        }
    }
}
