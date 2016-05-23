namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicle : IdParseEntity
    {
        public Vehicle()
        {
            this.Accessories = new HashSet<Accessory>();
        }
    
        public string Plate { get; set; }
        public string Engine { get; set; }
        public string Year { get; set; }
        public string Chassis { get; set; }
        public long PolicyId { get; set; }
        public Nullable<long> EndorseId { get; set; }
        public long VehicleModelId { get; set; }
        public long UseId { get; set; }
        public long BodyworkId { get; set; }
        public Nullable<bool> IsRemoved { get; set; }
    
        public virtual ICollection<Accessory> Accessories { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual Endorse Endorse { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public virtual Use Use { get; set; }
        public virtual Bodywork Bodywork { get; set; }
    }
}
