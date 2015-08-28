namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class CoveragesPack
    {
        public CoveragesPack()
        {
            this.Coverages = new HashSet<Coverage>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int RiskId { get; set; }
    
        public virtual Risk Risk { get; set; }
        public virtual ICollection<Coverage> Coverages { get; set; }
    }
}
