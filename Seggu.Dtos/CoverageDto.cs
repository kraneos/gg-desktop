using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class CoverageDto : KeyValueDto
    {
        public string Description { get; set; }
        public int RiskId { get; set; }
        public virtual IEnumerable<CoveragesPackDto> CoveragesPacks { get; set; }
    }
}
