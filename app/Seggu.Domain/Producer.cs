namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producer
    {
        public Producer()
        {
            this.ProducerCodes = new HashSet<ProducerCode>();
            this.CashAccounts = new HashSet<CashAccount>();
            this.Policies = new HashSet<Policy>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public bool IsCollector { get; set; }
    
        public virtual ICollection<ProducerCode> ProducerCodes { get; set; }
        public virtual ICollection<CashAccount> CashAccounts { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
    }
}
