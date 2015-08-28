namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicle
    {
        public Vehicle()
        {
            this.Accessories = new HashSet<Accessory>();
            this.Coverages = new HashSet<Coverage>();
        }
    
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Engine { get; set; }
        public string Year { get; set; }
        public string Chassis { get; set; }
        public int PolicyId { get; set; }
        public Nullable<int> EndorseId { get; set; }
        public int VehicleModelId { get; set; }
        public int UseId { get; set; }
        public int BodyworkId { get; set; }
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
