using Seggu.Data;
using Seggu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.DtoMappers
{
    public static class IntegralDtoMapper
    {
        public static IntegralDto GetDto(Integral obj)
        {
            var dto = new IntegralDto();
            dto.Address = obj.Address == null ? null : AddressDtoMapper.GetDto(obj.Address); 
            dto.Id = obj.Id.ToString();
            dto.Coverages = obj.Coverages.OrderBy(x => x.Name).Select(c => CoverageDtoMapper.GetDto(c)).ToList();
            dto.PolicyId = obj.PolicyId.ToString();
            dto.EndorseId = obj.EndorseId.ToString();
            return dto;
        }

        internal static Integral GetObjectWithCover(IntegralDto dto)
        {
            var obj = new Integral();            
            obj.Address = AddressDtoMapper.GetIntegralObjectAddress(dto.Address);
            obj.Coverages = dto.Coverages.Select(x => CoverageDtoMapper.GetObject(x)).ToList();
            obj.EndorseId = string.IsNullOrEmpty(dto.EndorseId) ? (Guid?)null : new Guid(dto.EndorseId);
            obj.PolicyId = string.IsNullOrEmpty(dto.PolicyId) ? (Guid?)null : new Guid(dto.PolicyId);
            obj.Id = string.IsNullOrEmpty(dto.Id) ? Guid.Empty : new Guid(dto.Id);
            return obj;
        }
    }
}
