using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class CoverageDto : KeyValueDto
    {
        public string Description { get; set; }
        public string RiskId { get; set; }
        public IEnumerable<CoveragesPackDto> CoveragesPacks { get; set; }
    }
}
