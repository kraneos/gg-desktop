namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleModel : ParseKeyValueEntity
    {
        public VehicleModel()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }
    
        public Origin Origin { get; set; }
        public long BrandId { get; set; }
        public long VehicleTypeId { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
