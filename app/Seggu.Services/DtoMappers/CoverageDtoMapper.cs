using Seggu.Domain;
using Seggu.Dtos;

namespace Seggu.Services.DtoMappers
{
    public class CoverageDtoMapper
    {
        public static CoverageDto GetDto(Coverage c)
        {
            var dto = new CoverageDto();
            dto.Id = (int)c.Id;
            dto.Name = c.Name;
            dto.Description = c.Description;
            //dto.Risks = c.Risks.Select(RiskDtoMapper.GetRiskCompanyDto);
            return dto;
        }
        public static Coverage GetObject(CoverageDto coverage)
        {
            var c = new Coverage();
            c.Id = coverage.Id;
            c.Name = string.IsNullOrEmpty(coverage.Name) ? "sin nombre" : coverage.Name;
            c.Description = coverage.Description;
            //c.Risks = coverage.Risks.Select(RiskDtoMapper.GetObject);
            return c;
        }
    }
}
