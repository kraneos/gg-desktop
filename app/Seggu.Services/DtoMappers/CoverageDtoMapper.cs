using Seggu.Domain;
using Seggu.Dtos;
using System;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public class CoverageDtoMapper
    {
        public static CoverageDto GetDto(Coverage c)
        {
            var dto = new CoverageDto();
            dto.Id = c.Id;
            dto.Name = c.Name;
            dto.Description = c.Description;
            dto.RiskId = c.RiskId;
            return dto;
        }
        public static Coverage GetObject(CoverageDto coverage)
        {
            var c = new Coverage();
            c.Id = coverage.Id;
            c.Name = string.IsNullOrEmpty(coverage.Name) ? "sin nombre" : coverage.Name;
            c.Description = coverage.Description;
            c.RiskId = coverage.RiskId;
            return c;
        }
    }
}
