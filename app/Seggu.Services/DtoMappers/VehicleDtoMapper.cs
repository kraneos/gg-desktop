using Seggu.Data;
using Seggu.Domain;
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
            dto.BodyworkId = obj.BodyworkId;
            dto.Bodywork = obj.Bodywork.Name;
            dto.BrandId = obj.VehicleModel.BrandId;
            dto.Brand = obj.VehicleModel.Brand.Name;
            dto.Chassis = obj.Chassis;
            dto.EndorseId = obj.EndorseId;
            dto.Engine = obj.Engine;
            dto.Id = obj.Id;
            dto.ModelId = obj.VehicleModelId;
            dto.Model = obj.VehicleModel.Name;
            dto.Origin = OriginDtoMapper.ToString(obj.VehicleModel.Origin);
            dto.Plate = obj.Plate;
            dto.PolicyId = obj.PolicyId;
            dto.Uso = obj.Use.Name;
            dto.UseId = obj.UseId;
            dto.VehicleType = obj.VehicleModel.VehicleType.Name;
            dto.VehicleTypeId = obj.VehicleModel.VehicleTypeId;
            dto.Year = obj.Year;
            dto.IsRemoved = (bool)(obj.IsRemoved ?? false);
            dto.Coverages = obj.Coverages.OrderBy(x => x.Name).Select(c => CoverageDtoMapper.GetDto(c)).ToList();

            return dto;
        }

        public static Vehicle GetObject(VehicleDto dto)
        {
            var obj = new Vehicle();
            obj.Id = dto.Id;
            obj.BodyworkId = dto.BodyworkId;
            obj.Chassis = dto.Chassis;
            obj.IsRemoved = dto.IsRemoved;
            obj.EndorseId = dto.EndorseId;
            obj.Engine = dto.Engine;
            obj.Plate = dto.Plate;
            obj.PolicyId = dto.PolicyId;
            obj.UseId = dto.UseId;
            obj.VehicleModelId = dto.ModelId;
            obj.Year = dto.Year;
            //obj.Accessories = dto.Accessories.Select(x => AccessoryDtoMapper.GetObject(x)).ToList();
            return obj;
        }
        public static Vehicle GetObjectWithCover(VehicleDto dto)
        {
            var obj = new Vehicle();

            obj.Id = dto.Id;
            obj.BodyworkId = dto.BodyworkId;
            obj.Chassis = dto.Chassis;
            obj.IsRemoved = dto.IsRemoved;
            obj.EndorseId = dto.EndorseId;
            obj.Engine = dto.Engine;
            obj.Plate = dto.Plate;
            obj.PolicyId = dto.PolicyId;
            var useId = default(int);
            if (dto.UseId == default(int))
            {
                useId = SegguContainer.Instance.Uses.First().Id;
            }
            else
            {
                useId = dto.UseId;
            }
            obj.UseId = useId;
            obj.VehicleModelId = dto.ModelId;
            obj.Year = dto.Year;
            obj.Coverages = dto.Coverages.Select(x => CoverageDtoMapper.GetObject(x)).ToList();
            //obj.Accessories = dto.Accessories == null ? null : dto.Accessories.Select(x => AccessoryDtoMapper.GetObject(x)).ToList();
            return obj;
        }
    }
}
