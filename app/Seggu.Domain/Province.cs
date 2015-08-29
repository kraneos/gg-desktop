namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Province : KeyValueEntity
    {
        public Province()
        {
            this.Districts = new HashSet<District>();
        }
        
        public virtual ICollection<District> Districts { get; set; }
    }
}
