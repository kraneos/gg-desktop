namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bank
    {
        public Bank()
        {
            this.ClientCreditCards = new HashSet<ClientCreditCard>();
            this.Cheques = new HashSet<Cheque>();
        }
    
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<ClientCreditCard> ClientCreditCards { get; set; }
        public virtual ICollection<Cheque> Cheques { get; set; }
    }
}
