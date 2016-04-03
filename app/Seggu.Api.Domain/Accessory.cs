namespace Seggu.Api.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Accessory : KeyValueEntity
    {
        public string Stamp { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public Guid AccessoryTypeId { get; set; }
        public decimal Value { get; set; }
        public Guid VehicleId { get; set; }
    
        public virtual AccessoryType AccessoryType { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
