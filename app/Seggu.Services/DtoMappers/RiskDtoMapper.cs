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
            dto.Id = (int)r.Id;
            dto.CompanyId = (int)r.CompanyId;
            dto.Name = r.Name;
            dto.RiskType = RiskTypeDtoMapper.ToString(r.RiskType);
            //dto.Coverages = r.Coverages.Select(c => CoverageDtoMapper.GetDto(c)).ToList();
            return dto;
        }

        public static Risk GetObject(RiskCompanyDto dto)
        {
            var obj = new Risk();
            obj.Id = dto.Id;
            obj.Name = dto.Name;
            obj.CompanyId = dto.CompanyId;
            obj.RiskType = RiskTypeDtoMapper.ToEnum(dto.RiskType);
            //obj.Coverages.Add(dto.Coverages);
            return obj;
        }
        public static Risk GetObjectWithCoverages(RiskCompanyDto dto)
        {
            var obj = new Risk();
            obj.Id = dto.Id;
            obj.Name = dto.Name;
            obj.CompanyId = dto.CompanyId;
            obj.RiskType = RiskTypeDtoMapper.ToEnum(dto.RiskType);
            obj.Coverages = dto.Coverages.Select(c => CoverageDtoMapper.GetObject(c)).ToList();
            return obj;
        }
    }
}
