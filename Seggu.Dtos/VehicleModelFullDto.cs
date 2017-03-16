using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Dtos
{
    public class VehicleModelFullDto : KeyValueDto
    {
        public string VehicleTypeName { get; set; }

        public string BrandName { get; set; }

        public string Origin { get; set; }
    }
}
