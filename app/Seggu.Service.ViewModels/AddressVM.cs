using System;

namespace Seggu.Service.ViewModels
{
    public class AddressVM : ParseViewModel
    {
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