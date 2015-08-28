namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class LedgerAccount
    {
        public LedgerAccount()
        {
            this.CashAccounts = new HashSet<CashAccount>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<CashAccount> CashAccounts { get; set; }
    }
}
