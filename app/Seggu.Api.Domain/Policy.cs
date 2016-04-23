namespace Seggu.Api.Domain
{
    using System;
    using System.Collections.Generic;

    public partial class Policy : IdEntity
    {
        public Policy()
        {
            this.Fees = new HashSet<Fee>();
            this.Casualties = new HashSet<Casualty>();
            this.Employees = new HashSet<Employee>();
            this.Vehicles = new HashSet<Vehicle>();
            this.Endorses = new HashSet<Endorse>();
            this.AttachedFiles = new HashSet<AttachedFile>();
            this.Integrals = new HashSet<Integral>();
        }

        public string PreviousNumber { get; set; }
        public Guid ClientId { get; set; }
        public Period Period { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.DateTime RequestDate { get; set; }
        public Nullable<System.DateTime> ReceptionDate { get; set; }
        public Nullable<System.DateTime> EmissionDate { get; set; }
        public decimal Prima { get; set; }
        public decimal Premium { get; set; }
        public decimal Surcharge { get; set; }
        public Nullable<decimal> Bonus { get; set; }
        public decimal Value { get; set; }
        public string Notes { get; set; }
        public string Number { get; set; }
        public bool IsRenovated { get; set; }
        public bool IsAnnulled { get; set; }
        public Nullable<System.DateTime> AnnulationDate { get; set; }
        public bool IsRemoved { get; set; }
        public Guid ProducerId { get; set; }
        public Nullable<Guid> CollectorId { get; set; }
        public Guid RiskId { get; set; }
        public int? PaymentDay { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<Casualty> Casualties { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Endorse> Endorses { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual Producer Collector { get; set; }
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; }
        public virtual Risk Risk { get; set; }
        public virtual ICollection<Integral> Integrals { get; set; }
    }
}
