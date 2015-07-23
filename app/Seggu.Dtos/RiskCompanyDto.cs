using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class RiskCompanyDto : KeyValueDto
    {
        public List<CoveragesPackDto> CoveragesPacks { get; set; }
        public string RiskType { get; set; }
        public string CompanyId { get; set; }
    }
}
