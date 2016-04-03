namespace Seggu.Api.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientCreditCard : IdEntity
    {
        public Nullable<long> Number { get; set; }
        public Guid ClientId { get; set; }
        public Guid CreditCardId { get; set; }
        public Guid BankId { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual Bank Bank { get; set; }
    }
}
