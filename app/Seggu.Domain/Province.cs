namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Province
    {
        public Province()
        {
            this.Districts = new HashSet<District>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<District> Districts { get; set; }
    }
}
