namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Company : KeyValueEntity
    {
        public Company()
        {
            this.ProducerCodes = new HashSet<ProducerCode>();
            this.CreditCards = new HashSet<CreditCard>();
            this.Contacts = new HashSet<Contact>();
            this.Risks = new HashSet<Risk>();
            this.Liquidations = new HashSet<Liquidation>();
        }
    
        public string Phone { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        public string EMail { get; set; }
        public string CUIT { get; set; }
        public int LiqDay1 { get; set; }
        public int LiqDay2 { get; set; }
        public int PaymentDay1 { get; set; }
        public int PaymentDay2 { get; set; }
    
        public virtual ICollection<ProducerCode> ProducerCodes { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Risk> Risks { get; set; }
        public virtual ICollection<Liquidation> Liquidations { get; set; }
    }
}
