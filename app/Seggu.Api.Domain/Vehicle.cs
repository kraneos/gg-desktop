namespace Seggu.Api.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicle : IdEntity
    {
        public Vehicle()
        {
            this.Accessories = new HashSet<Accessory>();
            this.Coverages = new HashSet<Coverage>();
        }
    
        public string Plate { get; set; }
        public string Engine { get; set; }
        public string Year { get; set; }
        public string Chassis { get; set; }
        public Guid PolicyId { get; set; }
        public Nullable<Guid> EndorseId { get; set; }
        public Guid VehicleModelId { get; set; }
        public Guid UseId { get; set; }
        public Guid BodyworkId { get; set; }
        public Nullable<bool> IsRemoved { get; set; }
    
        public virtual ICollection<Accessory> Accessories { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual Endorse Endorse { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public virtual Use Use { get; set; }
        public virtual Bodywork Bodywork { get; set; }
        public virtual ICollection<Coverage> Coverages { get; set; }
    }
}
