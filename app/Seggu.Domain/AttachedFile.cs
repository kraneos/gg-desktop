namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class AttachedFile
    {
        public int Id { get; set; }
        public Nullable<int> EndorseId { get; set; }
        public string FilePath { get; set; }
        public Nullable<int> PolicyId { get; set; }
        public Nullable<int> CasualtyId { get; set; }
        public Nullable<int> CashAccountId { get; set; }
    
        public virtual Endorse Endorse { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual Casualty Casualty { get; set; }
        public virtual CashAccount CashAccount { get; set; }
    }
}
