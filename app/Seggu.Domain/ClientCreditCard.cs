namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientCreditCard
    {
        public int Id { get; set; }
        public Nullable<long> Number { get; set; }
        public int ClientId { get; set; }
        public int CreditCardId { get; set; }
        public int BankId { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual Bank Bank { get; set; }
    }
}
