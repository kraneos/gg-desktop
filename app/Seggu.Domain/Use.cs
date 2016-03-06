namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Use : ParseKeyValueEntity
    {
        public Use()
        {
            this.VehicleType = new HashSet<VehicleType>();
            this.Vehicles = new HashSet<Vehicle>();
        }
        
        public virtual ICollection<VehicleType> VehicleType { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
