namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class FeeSelection: ParseKeyValueEntity
    {
        public FeeSelection()
        {
            this.Fees = new HashSet<Fee>();
        }
    
        public decimal Total { get; set; }
        public long LiquidationId { get; set; }
        public string Notes { get; set; }
    
        public virtual Liquidation Liquidation { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
    }
}
