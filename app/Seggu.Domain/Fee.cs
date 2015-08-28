namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fee
    {
        public Fee()
        {
            this.CashAccount = new HashSet<CashAccount>();
        }
    
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public short Number { get; set; }
        public decimal Value { get; set; }
        public decimal Balance { get; set; }
        public decimal CompanyPayment { get; set; }
        public bool Annulated { get; set; }
        public Nullable<int> FeeSelectionId { get; set; }
        public FeeState State { get; set; }
        public Nullable<int> EndorseId { get; set; }
        public string RegisteredLiqDate { get; set; }
    
        public virtual Policy Policy { get; set; }
        public virtual ICollection<CashAccount> CashAccount { get; set; }
        public virtual FeeSelection FeeSelection { get; set; }
        public virtual Endorse Endorse { get; set; }
    }
}
