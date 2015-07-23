using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Dtos
{
    [Serializable]
    public class IntegralDto
    {
        public string Id { get; set; }
        public AddressDto Address { get; set; }
        public string PolicyId { get; set; }
        public string EndorseId { get; set; }
        public IEnumerable<CoverageDto> Coverages { get; set; }
    }
}
