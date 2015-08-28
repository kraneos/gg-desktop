namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class CasualtyType
    {
        public CasualtyType()
        {
            this.Casualtys = new HashSet<Casualty>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Casualty> Casualtys { get; set; }
    }
}
