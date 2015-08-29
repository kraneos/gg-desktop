namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientCreditCard : IdEntity
    {
        public Nullable<long> Number { get; set; }
        public long ClientId { get; set; }
        public long CreditCardId { get; set; }
        public long BankId { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual Bank Bank { get; set; }
    }
}
