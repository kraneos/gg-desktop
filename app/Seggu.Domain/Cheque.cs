namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cheque : IdEntity
    {
        public string Number { get; set; }
        public long BankId { get; set; }
        public decimal Value { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Bank Bank { get; set; }
    }
}
