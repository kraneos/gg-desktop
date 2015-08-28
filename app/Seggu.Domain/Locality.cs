namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Locality
    {
        public Locality()
        {
            this.Addresses = new HashSet<Address>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }
    
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual District District { get; set; }
    }
}
