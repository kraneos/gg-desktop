namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Integral : IdParseEntity
    {
        public Integral()
        {
            this.Coverages = new HashSet<Coverage>();
        }
    
        public Nullable<long> PolicyId { get; set; }
        public Nullable<long> EndorseId { get; set; }
    
        public virtual ICollection<Coverage> Coverages { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual Endorse Endorse { get; set; }
        public virtual Address Address { get; set; }
    }
}
