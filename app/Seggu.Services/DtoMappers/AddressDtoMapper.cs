using Seggu.Domain;
using Seggu.Dtos;
using System;

namespace Seggu.Services.DtoMappers
{
    public class AddressDtoMapper
    {
        public static Address GetHome(ClientFullDto dto)
        {
            var obj = new Address();
            obj.Id = dto.HomeAddressId;
            obj.AddressType = AddressType.Home;
            obj.Appartment = dto.HomeAppartment;
            obj.ClientId = dto.Id;
            obj.Floor = dto.HomeFloor.ToString();
            obj.LocalityId = dto.HomeLocalityId;
            obj.Number = dto.HomeNumber.ToString();
            obj.Phone = dto.HomePhone;
            obj.PostalCode = dto.HomePostalCode;
            obj.Street = dto.HomeStreet;
            return obj;
        }

        public static Address GetCollection(ClientFullDto dto)
        {
            var obj = new Address();
            obj.Id = dto.CollectionAddressId;
            obj.AddressType = AddressType.Collection;
            obj.Appartment = dto.CollectionAppartment;
            obj.ClientId = dto.Id;
            obj.Floor = dto.CollectionFloor.ToString();
            obj.LocalityId = dto.CollectionLocalityId;
            obj.Number = dto.CollectionNumber.ToString();
            obj.Phone = dto.CollectionPhone;
            obj.PostalCode = dto.CollectionPostalCode;
            obj.Street = dto.CollectionStreet;
            return obj;
        }
        public static AddressDto GetDto(Address obj)
        {

            var dto = new AddressDto();
            dto.Id = (int)obj.Id;
            dto.AddressType = AddressType.Home.ToString();
            dto.Appartment = obj.Appartment;
            dto.ClientId = obj.ClientId.HasValue ? (int)obj.ClientId.Value : default(int);
            dto.Floor = obj.Floor;
            dto.LocalityId = (int?)obj.LocalityId ?? default(int);

            dto.ProvinceId = (int)obj.Locality.District.ProvinceId;
            dto.DistrictId = (int)obj.Locality.DistrictId;

            dto.Number = obj.Number;
            dto.Phone = obj.Phone;
            dto.PostalCode = obj.PostalCode;
            dto.Street = obj.Street;
            return dto;
        }
        public static Address GetIntegralObjectAddress(AddressDto dto)
        {
            var obj = new Address();
            obj.Id = dto.Id;
            obj.AddressType = AddressType.Home;
            obj.Appartment = dto.Appartment;
            obj.ClientId = null;
            obj.Floor = dto.Floor;
            obj.LocalityId = dto.LocalityId;
            obj.Number = dto.Number.ToString();
            obj.PostalCode = dto.PostalCode;
            obj.Street = dto.Street;
            return obj;
        }
    }
}