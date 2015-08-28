namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class District
    {
        public District()
        {
            this.Localities = new HashSet<Locality>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
    
        public virtual Province Province { get; set; }
        public virtual ICollection<Locality> Localities { get; set; }
    }
}
