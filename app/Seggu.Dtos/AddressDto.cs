using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class AddressDto : EntityWithIdDto
    {
        public string Appartment { get; set; }
        public string AddressType { get; set; }
        public string ClientId { get; set; }
        public string Floor { get; set; }
        public string LocalityId { get; set; }
        public string ProvinceId { get; set; }
        public string DistrictId { get; set; }

        public string Number { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
    }
}
