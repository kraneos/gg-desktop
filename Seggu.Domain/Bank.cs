namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bank : ParseKeyValueEntity
    {
        public Bank()
        {
            this.ClientCreditCards = new HashSet<ClientCreditCard>();
            this.Cheques = new HashSet<Cheque>();
        }
    
        public string Number { get; set; }
    
        public virtual ICollection<ClientCreditCard> ClientCreditCards { get; set; }
        public virtual ICollection<Cheque> Cheques { get; set; }
    }
}
