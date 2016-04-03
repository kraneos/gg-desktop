namespace Seggu.Api.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class AttachedFile : IdEntity
    {
        public Nullable<Guid> EndorseId { get; set; }
        public string FilePath { get; set; }
        public Nullable<Guid> PolicyId { get; set; }
        public Nullable<Guid> CasualtyId { get; set; }
        public Nullable<Guid> CashAccountId { get; set; }
    
        public virtual Endorse Endorse { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual Casualty Casualty { get; set; }
        public virtual CashAccount CashAccount { get; set; }
    }
}
