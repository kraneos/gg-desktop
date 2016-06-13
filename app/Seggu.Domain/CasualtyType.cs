namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class CasualtyType : ParseKeyValueEntity
    {
        public CasualtyType()
        {
            this.Casualtys = new HashSet<Casualty>();
        }
    
        public virtual ICollection<Casualty> Casualtys { get; set; }
    }
}
