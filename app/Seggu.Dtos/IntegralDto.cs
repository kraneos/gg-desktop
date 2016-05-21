using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class IntegralDto
    {
        public int Id { get; set; }
        public AddressDto Address { get; set; }
        public int PolicyId { get; set; }
        public int EndorseId { get; set; }
        public IEnumerable<CoverageDto> Coverages { get; set; }

        public string province { get; set; }
        public string locality { get; set; }
        public string district { get; set; }
    }
}
