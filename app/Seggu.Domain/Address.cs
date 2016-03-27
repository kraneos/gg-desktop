namespace Seggu.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address : IdParseEntity
    {
        public string Street { get; set; }
        public string Phone { get; set; }
        public string Number { get; set; }
        public string Floor { get; set; }
        public string Appartment { get; set; }
        public Nullable<long> LocalityId { get; set; }
        public string PostalCode { get; set; }
        public AddressType AddressType { get; set; }
        public Nullable<long> ClientId { get; set; }
    
        public virtual Locality Locality { get; set; }
        public virtual Client Client { get; set; }
        public virtual Integral Integral { get; set; }
    }
}
