using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class VehicleModelVM : KeyValueViewModel
    {
        public int Origin { get; set; }
        public string BrandId { get; set; }
        public string VehicleTypeId { get; set; }

    }
}
