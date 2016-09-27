using Seggu.Domain;
using Seggu.Dtos;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class IntegralDtoMapper
    {
        public static IntegralDto GetDto(Integral obj)
        {
            var dto = new IntegralDto();
            dto.Address = obj.Address == null ? null : AddressDtoMapper.GetDto(obj.Address);
            dto.Id = (int)obj.Id;
            dto.Coverages = obj.Coverages.OrderBy(x => x.Name).Select(c => CoverageDtoMapper.GetDto(c)).ToList();
            dto.PolicyId = ((int?)obj.PolicyId) ?? default(int);
            dto.EndorseId = ((int?)obj.EndorseId);
            dto.locality = obj.Address.Locality.Name;
            return dto;
        }

        internal static Integral GetObjectWithCover(IntegralDto dto)
        {
            var obj = new Integral();
            obj.Address = AddressDtoMapper.GetIntegralObjectAddress(dto.Address);
            obj.Coverages = dto.Coverages.Select(x => CoverageDtoMapper.GetObject(x)).ToList();
            obj.EndorseId = dto.EndorseId;
            obj.PolicyId = dto.PolicyId;
            obj.Id = dto.Id;
            return obj;
        }
    }
}
