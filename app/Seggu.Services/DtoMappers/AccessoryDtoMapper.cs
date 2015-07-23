using Seggu.Data;
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
            dto.Id = obj.Id.ToString();
            dto.Name = obj.Name;
            dto.Vencimiento = obj.ExpirationDate;
            dto.Oblea = obj.Stamp;
            dto.Valor = obj.Value;
            dto.VehicleId = obj.VehicleId.ToString();
            dto.AccessoryTypeId = obj.AccessoryTypeId.ToString();
            return dto;
        }

        public static Accessory GetObject(AccessoryDto dto)
        {
            var obj = new Accessory();
            obj.Id = string.IsNullOrEmpty(dto.Id) ? Guid.Empty : new Guid(dto.Id);
            obj.VehicleId = new Guid(dto.VehicleId);
            obj.AccessoryTypeId = new Guid(dto.AccessoryTypeId);
            obj.ExpirationDate = dto.Vencimiento;
            obj.Stamp = dto.Oblea;
            obj.Name = dto.Name;
            obj.Value = dto.Valor;
            return obj;
        }
    }
}
