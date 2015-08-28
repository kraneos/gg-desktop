namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asset
    {
        public Asset()
        {
            this.CashAccounts = new HashSet<CashAccount>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    
        public virtual ICollection<CashAccount> CashAccounts { get; set; }
    }
}
