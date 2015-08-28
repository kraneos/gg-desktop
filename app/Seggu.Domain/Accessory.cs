namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Accessory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stamp { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public int AccessoryTypeId { get; set; }
        public decimal Value { get; set; }
        public int VehicleId { get; set; }
    
        public virtual AccessoryType AccessoryType { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
