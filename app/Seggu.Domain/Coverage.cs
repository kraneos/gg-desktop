namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Coverage : KeyValueEntity
    {
        public Coverage()
        {
            this.Integrals = new HashSet<Integral>();
            this.Employees = new HashSet<Employee>();
            this.Vehicles = new HashSet<Vehicle>();
            this.CoveragesPacks = new HashSet<CoveragesPack>();
        }
    
        public string Description { get; set; }
        public long RiskId { get; set; }
    
        public virtual ICollection<Integral> Integrals { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual Risk Risk { get; set; }
        public virtual ICollection<CoveragesPack> CoveragesPacks { get; set; }
    }
}
