using System;

namespace Seggu.Service
{
    public class AddressVM
    {
        public string ObjectId { get; set; }
        public DateVM CreatedAt { get; set; }
        public DateVM UpdatedAt { get; set; }
        public DateVM LocallyUpdatedAt { get; set; }
        public long Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Floor { get; set; }
        public string Appartment { get; set; }
        public string PostalCode { get; set; }
        public long? LocalityId { get; set; }
        public string LocalityName { get; set; }
        public string ProvinceName { get; set; }
    }
}