namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Endorse
    {
        public Endorse()
        {
            this.Employees = new HashSet<Employee>();
            this.Vehicles = new HashSet<Vehicle>();
            this.Fees = new HashSet<Fee>();
            this.AttachedFiles = new HashSet<AttachedFile>();
            this.Integrals = new HashSet<Integral>();
        }
    
        public int Id { get; set; }
        public EndorseType EndorseType { get; set; }
        public string Number { get; set; }
        public string Cause { get; set; }
        public int PolicyId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.DateTime RequestDate { get; set; }
        public Nullable<System.DateTime> ReceptionDate { get; set; }
        public Nullable<System.DateTime> EmissionDate { get; set; }
        public Nullable<decimal> Prima { get; set; }
        public Nullable<decimal> Premium { get; set; }
        public Nullable<decimal> Surcharge { get; set; }
        public Nullable<decimal> Value { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> IsAnnulled { get; set; }
        public Nullable<System.DateTime> AnnulationDate { get; set; }
        public Nullable<bool> IsRemoved { get; set; }
    
        public virtual Policy Policy { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; }
        public virtual ICollection<Integral> Integrals { get; set; }
    }
}
