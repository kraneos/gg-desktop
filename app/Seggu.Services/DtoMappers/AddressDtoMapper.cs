using Seggu.Data;
using Seggu.Dtos;
using System;

namespace Seggu.Services.DtoMappers
{
    public class AddressDtoMapper
    {
        public static Address GetHome(ClientFullDto dto)
        {
            var obj = new Address();
            obj.Id = string.IsNullOrEmpty(dto.HomeAddressId) ? Guid.Empty : new Guid(dto.HomeAddressId);
            obj.AddressType = AddressType.Home;
            obj.Appartment = dto.HomeAppartment;
            obj.ClientId = string.IsNullOrEmpty(dto.Id) ? Guid.Empty : new Guid(dto.Id);
            obj.Floor = dto.HomeFloor.ToString();
            obj.LocalityId = string.IsNullOrEmpty(dto.HomeLocalityId) ? Guid.Empty : new Guid(dto.HomeLocalityId);
            obj.Number = dto.HomeNumber.ToString();
            obj.Phone = dto.HomePhone;
            obj.PostalCode = dto.HomePostalCode;
            obj.Street = dto.HomeStreet;
            return obj;
        }

        public static Address GetCollection(ClientFullDto dto)
        {
            var obj = new Address();
            obj.Id = string.IsNullOrEmpty(dto.CollectionAddressId) ? Guid.Empty : new Guid(dto.CollectionAddressId);
            obj.AddressType = AddressType.Collection;
            obj.Appartment = dto.CollectionAppartment;
            obj.ClientId = string.IsNullOrEmpty(dto.Id) ? Guid.Empty : new Guid(dto.Id);
            obj.Floor = dto.CollectionFloor.ToString();
            obj.LocalityId = string.IsNullOrEmpty(dto.CollectionLocalityId) ? Guid.Empty : new Guid(dto.CollectionLocalityId);
            obj.Number = dto.CollectionNumber.ToString();
            obj.Phone = dto.CollectionPhone;
            obj.PostalCode = dto.CollectionPostalCode;
            obj.Street = dto.CollectionStreet;
            return obj;
        }
        public static AddressDto GetDto(Address obj)
        {

            var dto = new AddressDto();
            dto.Id = obj.Id == null ? null : obj.Id.ToString();
            dto.AddressType = AddressType.Home.ToString();
            dto.Appartment = obj.Appartment;
            dto.ClientId = obj.ClientId == null ? null : obj.ClientId.ToString();
            dto.Floor = obj.Floor;
            dto.LocalityId = obj.LocalityId == null ? null : obj.LocalityId.ToString();

            dto.ProvinceId = obj.Locality.District.ProvinceId.ToString();
            dto.DistrictId = obj.Locality.DistrictId.ToString();

            dto.Number = obj.Number;
            dto.Phone = obj.Phone;
            dto.PostalCode = obj.PostalCode;
            dto.Street = obj.Street;
            return dto;
        }
        public static Address GetIntegralObjectAddress(AddressDto dto)
        {
            var obj = new Address();
            obj.Id = string.IsNullOrEmpty(dto.Id) ? Guid.Empty : new Guid(dto.Id);
            obj.AddressType = AddressType.Home;
            obj.Appartment = dto.Appartment;
            obj.ClientId = null;
            obj.Floor = dto.Floor;
            obj.LocalityId = string.IsNullOrEmpty(dto.LocalityId) ? Guid.Empty : new Guid(dto.LocalityId);
            obj.Number = dto.Number.ToString();
            obj.PostalCode = dto.PostalCode;
            obj.Street = dto.Street;
            return obj;
        }
    }
}