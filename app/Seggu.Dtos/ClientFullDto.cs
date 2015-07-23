using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class ClientFullDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Tel_Móvil { get; set; }
        public string DocumentTypes { get; set; }
        public string DNI { get; set; }
        public string BirthDate { get; set; }
        public string Cuit { get; set; }
        public string IngresosBrutos { get; set; }
        public string CollectionTimeRange { get; set; }
        public string BankingCode { get; set; }
        public string Notes { get; set; }
        public bool IsSmoker { get; set; }
        public string Sex { get; set; }
        public string HomeStreet { get; set; }
        public string HomeNumber { get; set; }
        public string HomeFloor { get; set; }
        public string HomeAppartment { get; set; }
        public string HomePostalCode { get; set; }
        public string HomeLocalityId { get; set; }
        public string HomeLocality { get; set; }
        public string HomeDistrictId { get; set; }
        public string HomeProvinceId { get; set; }
        public string HomePhone { get; set; }
        public string MaritalStatus { get; set; }
        public string Iva { get; set; }
        public string Mail { get; set; }
        public string Occupation { get; set; }
        public string Id { get; set; }
        public string CollectionAppartment { get; set; }
        public string CollectionFloor { get; set; }
        public string CollectionLocalityId { get; set; }
        public string CollectionDistrictId { get; set; }
        public string CollectionProvinceId { get; set; }
        public string CollectionNumber { get; set; }
        public string CollectionPhone { get; set; }
        public string CollectionPostalCode { get; set; }
        public string CollectionStreet { get; set; }
        public IEnumerable<ClientCreditCardInformationDto> CreditCards { get; set; }
        public string HomeAddressId { get; set; }
        public string CollectionAddressId { get; set; }
        public int PolicyCount { get; set; }
    }
}
