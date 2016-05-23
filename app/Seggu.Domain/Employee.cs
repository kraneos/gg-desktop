namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee : IdParseEntity
    {
        public Employee()
        {
        }
    
        public long PolicyId { get; set; }
        public Nullable<long> EndorseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string DNI { get; set; }
        public string CUIT { get; set; }
        public Nullable<bool> IsRemoved { get; set; }
        public decimal InsuranceAmount { get; set; }
    
        public virtual Policy Policy { get; set; }
        public virtual Endorse Endorse { get; set; }
    }
}
