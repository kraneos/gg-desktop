namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class FeeSelection
    {
        public FeeSelection()
        {
            this.Fees = new HashSet<Fee>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Total { get; set; }
        public int LiquidationId { get; set; }
        public string Notes { get; set; }
    
        public virtual Liquidation Liquidation { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
    }
}
