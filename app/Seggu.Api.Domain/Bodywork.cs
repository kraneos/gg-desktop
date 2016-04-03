namespace Seggu.Api.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bodywork : KeyValueEntity
    {
        public Bodywork()
        {
            this.VehicleTypes = new HashSet<VehicleType>();
            this.Vehicles = new HashSet<Vehicle>();
        }
    
        public virtual ICollection<VehicleType> VehicleTypes { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
