using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class CoveragesPackDto : KeyValueDto
    {
        public string RiskId { get; set; }
        public List<CoverageDto> Coverages { get; set; }

    }
}
