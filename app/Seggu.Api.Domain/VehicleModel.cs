namespace Seggu.Api.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleModel : KeyValueEntity
    {
        public VehicleModel()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }
    
        public Origin Origin { get; set; }
        public Guid BrandId { get; set; }
        public Guid VehicleTypeId { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
