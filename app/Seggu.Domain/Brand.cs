namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Brand
    {
        public Brand()
        {
            this.VehicleModels = new HashSet<VehicleModel>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
