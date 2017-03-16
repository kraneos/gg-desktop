namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asset : ParseKeyValueEntity
    {
        public Asset()
        {
            this.CashAccounts = new HashSet<CashAccount>();
        }
    
        public decimal Amount { get; set; }
    
        public virtual ICollection<CashAccount> CashAccounts { get; set; }
    }
}
