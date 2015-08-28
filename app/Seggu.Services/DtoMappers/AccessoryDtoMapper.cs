using Seggu.Domain;
using Seggu.Dtos;
using System;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class AccessoryDtoMapper
    {
        public static AccessoryDto GetDto(Accessory obj)
        {
            var dto = new AccessoryDto();
            dto.Id = obj.Id;
            dto.Name = obj.Name;
            dto.Vencimiento = obj.ExpirationDate;
            dto.Oblea = obj.Stamp;
            dto.Valor = obj.Value;
            dto.VehicleId = obj.VehicleId;
            dto.AccessoryTypeId = obj.AccessoryTypeId;
            return dto;
        }

        public static Accessory GetObject(AccessoryDto dto)
        {
            var obj = new Accessory();
            obj.Id = dto.Id;
            obj.VehicleId = dto.VehicleId;
            obj.AccessoryTypeId = dto.AccessoryTypeId;
            obj.ExpirationDate = dto.Vencimiento;
            obj.Stamp = dto.Oblea;
            obj.Name = dto.Name;
            obj.Value = dto.Valor;
            return obj;
        }
    }
}
