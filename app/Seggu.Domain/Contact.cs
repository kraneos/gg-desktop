namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Notes { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string Bussiness { get; set; }
    
        public virtual Company Company { get; set; }
    }
}
