using Seggu.Data;
using Seggu.Dtos;
using System;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class RiskDtoMapper
    {
        public static RiskCompanyDto GetRiskCompanyDto(Risk r)
        {
            var dto = new RiskCompanyDto();
            dto.Id = r.Id.ToString();
            dto.Name = r.Name;
            dto.RiskType = RiskTypeDtoMapper.ToString(r.RiskType);
            dto.CoveragesPacks = r.CoveragesPacks.Select(c => CoveragesPackDtoMapper.GetDto(c)).ToList();
            return dto;
        }

        public static Risk GetObject(RiskCompanyDto dto)
        {
            var obj = new Risk();
            obj.Id = string.IsNullOrEmpty(dto.Id) ? Guid.Empty : new Guid(dto.Id);
            obj.Name = dto.Name;
            obj.CompanyId = new Guid(dto.CompanyId);
            obj.RiskType = RiskTypeDtoMapper.ToEnum(dto.RiskType);
            return obj;
        }
    }
}
