namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class AttachedFile : IdEntity
    {
        public Nullable<long> EndorseId { get; set; }
        public string FilePath { get; set; }
        public Nullable<long> PolicyId { get; set; }
        public Nullable<long> CasualtyId { get; set; }
        public Nullable<long> CashAccountId { get; set; }
    
        public virtual Endorse Endorse { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual Casualty Casualty { get; set; }
        public virtual CashAccount CashAccount { get; set; }
    }
}
