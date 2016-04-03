namespace Seggu.Api.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Liquidation : IdEntity
    {
        public Liquidation()
        {
            this.FeeSelections = new HashSet<FeeSelection>();
        }
    
        public System.DateTime Date { get; set; }
        public decimal Total { get; set; }
        public Nullable<System.DateTime> ReceptionDate { get; set; }
        public bool Registered { get; set; }
        public string Notes { get; set; }
        public Guid CompanyId { get; set; }
    
        public virtual ICollection<FeeSelection> FeeSelections { get; set; }
        public virtual Company Company { get; set; }
    }
}
