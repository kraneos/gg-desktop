namespace Seggu.Api.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class District : KeyValueEntity
    {
        public District()
        {
            this.Localities = new HashSet<Locality>();
        }
    
        public Guid ProvinceId { get; set; }
    
        public virtual Province Province { get; set; }
        public virtual ICollection<Locality> Localities { get; set; }
    }
}
