namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class CreditCard
    {
        public CreditCard()
        {
            this.ClientCreditCards = new HashSet<ClientCreditCard>();
            this.Companies = new HashSet<Company>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<ClientCreditCard> ClientCreditCards { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
