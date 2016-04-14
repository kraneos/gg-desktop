using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class AccessoryVM : KeyValueViewModel
    {
        public string Stamp { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public Guid AccessoryTypeId { get; set; }
        public decimal Value { get; set; }
        public Guid VehicleId { get; set; }
    }
}
