namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleModel
    {
        public VehicleModel()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Origin Origin { get; set; }
        public int BrandId { get; set; }
        public int VehicleTypeId { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
