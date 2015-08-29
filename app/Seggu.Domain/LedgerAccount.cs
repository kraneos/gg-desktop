namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class LedgerAccount : KeyValueEntity
    {
        public LedgerAccount()
        {
            this.CashAccounts = new HashSet<CashAccount>();
        }
    
        public virtual ICollection<CashAccount> CashAccounts { get; set; }
    }
}
