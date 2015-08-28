namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.Coverages = new HashSet<Coverage>();
        }
    
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public Nullable<int> EndorseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string DNI { get; set; }
        public string CUIT { get; set; }
        public Nullable<bool> IsRemoved { get; set; }
        public decimal InsuranceAmount { get; set; }
    
        public virtual Policy Policy { get; set; }
        public virtual Endorse Endorse { get; set; }
        public virtual ICollection<Coverage> Coverages { get; set; }
    }
}
