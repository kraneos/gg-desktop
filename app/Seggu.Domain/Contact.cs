namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact : IdEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Notes { get; set; }
        public Nullable<long> CompanyId { get; set; }
        public string Bussiness { get; set; }
    
        public virtual Company Company { get; set; }
    }
}
