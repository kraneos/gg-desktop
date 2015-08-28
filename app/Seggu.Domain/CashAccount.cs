namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class CashAccount
    {
        public CashAccount()
        {
            this.AttachedFiles = new HashSet<AttachedFile>();
        }
    
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int LedgerAccountId { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public int ProducerId { get; set; }
        public Nullable<int> FeeId { get; set; }
        public string ReceiptNumber { get; set; }
    
        public virtual LedgerAccount LedgerAccount { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual Fee Fee { get; set; }
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; }
    }
}
