namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class District : ParseKeyValueEntity
    {
        public District()
        {
            this.Localities = new HashSet<Locality>();
        }
    
        public long ProvinceId { get; set; }
    
        public virtual Province Province { get; set; }
        public virtual ICollection<Locality> Localities { get; set; }
    }
}
