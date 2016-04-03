namespace Seggu.Api.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Casualty : IdEntity
    {
        public Casualty()
        {
            this.AttachedFiles = new HashSet<AttachedFile>();
        }
    
        public Guid PolicyId { get; set; }
        public int Number { get; set; }
        public Guid CasualtyTypeId { get; set; }
        public bool OurCharge { get; set; }
        public System.DateTime OccurredDate { get; set; }
        public System.DateTime ReceiveDate { get; set; }
        public Nullable<System.DateTime> PoliceReportDate { get; set; }
        public decimal EstimatedCompensation { get; set; }
        public decimal DefinedCompensation { get; set; }
        public string Notes { get; set; }
    
        public virtual CasualtyType CasualtyType { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; }
    }
}
