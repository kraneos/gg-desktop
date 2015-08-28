using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class AddressDto : EntityWithIdDto
    {
        public string Appartment { get; set; }
        public string AddressType { get; set; }
        public int ClientId { get; set; }
        public string Floor { get; set; }
        public int LocalityId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }

        public string Number { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
    }
}
