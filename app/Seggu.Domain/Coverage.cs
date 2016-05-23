namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Coverage : ParseKeyValueEntity
    {
        public Coverage()
        {
            this.Policies = new HashSet<Policy>();
            this.Endorses = new HashSet<Endorse>();
            this.Risks = new HashSet<Risk>();
        }
    
        public string Description { get; set; }
    
        public virtual ICollection<Risk> Risks { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
        public virtual ICollection<Endorse> Endorses { get; set; }
    }
}
