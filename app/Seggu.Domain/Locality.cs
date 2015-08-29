namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Locality : KeyValueEntity
    {
        public Locality()
        {
            this.Addresses = new HashSet<Address>();
        }
    
        public long DistrictId { get; set; }
    
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual District District { get; set; }
    }
}
