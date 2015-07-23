using Seggu.Data;
using Seggu.Dtos;
using System;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class VehicleDtoMapper
    {
        public static VehicleDto GetDto(Vehicle obj)
        {
            var dto = new VehicleDto();
            //dto.Accessories = obj.Accessories.Select(x => AccessoryDtoMapper.GetDto(x)).ToList();
            dto.BodyworkId = obj.BodyworkId.ToString();
            dto.Bodywork = obj.Bodywork.Name;
            dto.BrandId = obj.VehicleModel.BrandId.ToString();
            dto.Brand = obj.VehicleModel.Brand.Name;
            dto.Chassis = obj.Chassis;
            dto.EndorseId = obj.EndorseId == null ? null : obj.EndorseId.ToString();
            dto.Engine = obj.Engine;
            dto.Id = obj.Id.ToString();
            dto.ModelId = obj.VehicleModelId.ToString();
            dto.Model = obj.VehicleModel.Name;
            dto.Origin = OriginDtoMapper.ToString(obj.VehicleModel.Origin);
            dto.Plate = obj.Plate;
            dto.PolicyId = obj.PolicyId.ToString();
            dto.Uso = obj.Use.Name;
            dto.UseId = obj.UseId.ToString();
            dto.VehicleType = obj.VehicleModel.VehicleType.Name;
            dto.VehicleTypeId = obj.VehicleModel.VehicleTypeId.ToString();
            dto.Year = obj.Year;
            dto.IsRemoved = (bool)(obj.IsRemoved ?? false);
            dto.Coverages = obj.Coverages.OrderBy(x => x.Name).Select(c => CoverageDtoMapper.GetDto(c)).ToList();

            return dto;
        }

        public static Vehicle GetObject(VehicleDto dto)
        {
            var obj = new Vehicle();
            obj.Id = string.IsNullOrEmpty(dto.Id) ? Guid.Empty : new Guid(dto.Id);
            obj.BodyworkId = new Guid(dto.BodyworkId);
            obj.Chassis = dto.Chassis;
            obj.IsRemoved = dto.IsRemoved;
            obj.EndorseId = dto.EndorseId == null ? (Guid?)null : new Guid(dto.EndorseId);
            obj.Engine = dto.Engine;
            obj.Plate = dto.Plate;
            obj.PolicyId = string.IsNullOrEmpty(dto.PolicyId) ? Guid.Empty : new Guid(dto.PolicyId);
            obj.UseId = new Guid(dto.UseId);
            obj.VehicleModelId = new Guid(dto.ModelId);
            obj.Year = dto.Year;
            //obj.Accessories = dto.Accessories.Select(x => AccessoryDtoMapper.GetObject(x)).ToList();
            return obj;
        }
        public static Vehicle GetObjectWithCover(VehicleDto dto)
        {
            var obj = new Vehicle();

            obj.Id = string.IsNullOrEmpty(dto.Id) ? Guid.Empty : new Guid(dto.Id);
            obj.BodyworkId = new Guid(dto.BodyworkId);
            obj.Chassis = dto.Chassis;
            obj.IsRemoved = dto.IsRemoved;
            obj.EndorseId = dto.EndorseId == null ? (Guid?)null : new Guid(dto.EndorseId);
            obj.Engine = dto.Engine;
            obj.Plate = dto.Plate;
            obj.PolicyId = string.IsNullOrEmpty(dto.PolicyId) ? Guid.Empty : new Guid(dto.PolicyId);
            var useId = Guid.Empty;
            if (string.IsNullOrEmpty(dto.UseId))
            {
                useId = SegguContainer.Instance.Uses.First().Id;
            }
            else
            {
                useId = new Guid(dto.UseId);
            }
            obj.UseId = useId;
            obj.VehicleModelId = new Guid(dto.ModelId);
            obj.Year = dto.Year;
            obj.Coverages = dto.Coverages.Select(x => CoverageDtoMapper.GetObject(x)).ToList();
            //obj.Accessories = dto.Accessories == null ? null : dto.Accessories.Select(x => AccessoryDtoMapper.GetObject(x)).ToList();
            return obj;
        }
    }
}
