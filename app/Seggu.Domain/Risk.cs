namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Risk : KeyValueEntity
    {
        public Risk()
        {
            this.CoveragesPacks = new HashSet<CoveragesPack>();
            this.Policy = new HashSet<Policy>();
            this.Coverages = new HashSet<Coverage>();
        }
    
        public RiskType RiskType { get; set; }
        public long CompanyId { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual ICollection<CoveragesPack> CoveragesPacks { get; set; }
        public virtual ICollection<Policy> Policy { get; set; }
        public virtual ICollection<Coverage> Coverages { get; set; }
    }
}
