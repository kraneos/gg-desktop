namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bodywork
    {
        public Bodywork()
        {
            this.VehicleTypes = new HashSet<VehicleType>();
            this.Vehicles = new HashSet<Vehicle>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<VehicleType> VehicleTypes { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
