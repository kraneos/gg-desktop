using Seggu.Domain;
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
            dto.Id = r.Id;
            dto.Name = r.Name;
            dto.RiskType = RiskTypeDtoMapper.ToString(r.RiskType);
            dto.CoveragesPacks = r.CoveragesPacks.Select(c => CoveragesPackDtoMapper.GetDto(c)).ToList();
            return dto;
        }

        public static Risk GetObject(RiskCompanyDto dto)
        {
            var obj = new Risk();
            obj.Id = dto.Id;
            obj.Name = dto.Name;
            obj.CompanyId = dto.CompanyId;
            obj.RiskType = RiskTypeDtoMapper.ToEnum(dto.RiskType);
            return obj;
        }
    }
}
