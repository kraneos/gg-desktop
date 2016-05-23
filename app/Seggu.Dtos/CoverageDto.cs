using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class CoverageDto : KeyValueDto
    {
        public string Description { get; set; }
        public IEnumerable<RiskCompanyDto> Risks { get; set; }
        //public virtual IEnumerable<CoveragesPackDto> CoveragesPacks { get; set; }
    }
}
