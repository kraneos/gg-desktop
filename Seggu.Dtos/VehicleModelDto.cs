﻿using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class VehicleModelDto : KeyValueDto
    {
        public string Origin { get; set; }
        public int BrandId { get; set; }
        public int VehicleTypeId { get; set; }
        public IEnumerable<BodyworkDto> Bodyworks { get; set; }
        public IEnumerable<UseDto> Uses { get; set; }
    }
}
