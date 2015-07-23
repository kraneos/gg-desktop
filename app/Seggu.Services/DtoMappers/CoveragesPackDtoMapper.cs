using Seggu.Data;
using Seggu.Dtos;
using System.Linq;
using System;

namespace Seggu.Services.DtoMappers
{
    public class CoveragesPackDtoMapper
    {
        public static CoveragesPackDto GetDto(CoveragesPack cp)
        {
            var dto = new CoveragesPackDto();
            dto.Id = cp.Id.ToString();
            dto.Name = cp.Name;
            dto.RiskId = cp.RiskId.ToString();
            dto.Coverages = cp.Coverages == null ? null 
                : cp.Coverages.Select(x => CoverageDtoMapper.GetDto(x)).ToList();
            return dto;
        }
        public static CoveragesPack GetObject(CoveragesPackDto coveragePack)
        {
            var cp = new CoveragesPack();
            cp.Id = string.IsNullOrEmpty(coveragePack.Id) ? Guid.Empty : new Guid(coveragePack.Id);
            cp.Name = string.IsNullOrEmpty(coveragePack.Name) ? "sin nombre" : coveragePack.Name;
            cp.RiskId = new Guid(coveragePack.RiskId);
            cp.Coverages = coveragePack.Coverages == null ? null
                : coveragePack.Coverages.Select(x => CoverageDtoMapper.GetObject(x)).ToList();

            return cp;
        }
    }
}