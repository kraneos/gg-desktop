using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class VehicleDto : EntityWithIdDto
    {
        public string BrandId { get; set; }
        public string Brand { get; set; }
        public string ModelId { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Engine { get; set; }
        public string EndorseId { get; set; }
        public string PolicyId { get; set; }
        public string Chassis { get; set; }
        public string Plate { get; set; }
        public string VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
        public string BodyworkId { get; set; }
        public string Bodywork { get; set; }
        public string Uso { get; set; }
        public string UseId { get; set; }
        public string Origin { get; set; }
        public bool IsRemoved { get; set; }
        public IEnumerable<AccessoryDto> Accessories { get; set; }
        public IEnumerable<CoverageDto> Coverages { get; set; }

    }
}
