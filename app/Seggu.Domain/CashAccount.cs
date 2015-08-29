namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class CashAccount : IdEntity
    {
        public CashAccount()
        {
            this.AttachedFiles = new HashSet<AttachedFile>();
        }
    
        public long AssetId { get; set; }
        public long LedgerAccountId { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public long ProducerId { get; set; }
        public Nullable<long> FeeId { get; set; }
        public string ReceiptNumber { get; set; }
    
        public virtual LedgerAccount LedgerAccount { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual Fee Fee { get; set; }
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; }
    }
}
