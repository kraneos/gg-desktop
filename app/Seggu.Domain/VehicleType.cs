namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleType
    {
        public VehicleType()
        {
            this.Uses = new HashSet<Use>();
            this.Bodyworks = new HashSet<Bodywork>();
            this.VehicleModels = new HashSet<VehicleModel>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Use> Uses { get; set; }
        public virtual ICollection<Bodywork> Bodyworks { get; set; }
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
