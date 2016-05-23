using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class RiskCompanyDto : KeyValueDto
    {
        public List<CoverageDto> Coverages { get; set; }
        public string RiskType { get; set; }
        public int CompanyId { get; set; }
    }
}
