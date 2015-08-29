namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Brand : KeyValueEntity
    {
        public Brand()
        {
            this.VehicleModels = new HashSet<VehicleModel>();
        }
    
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
