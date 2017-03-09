using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class ClientDtoMapper
    {
        public static Client GetObject(ClientFullDto dto)
        {
            var obj = new Client();
            obj.Id = dto.Id;

            obj.BankingCode = dto.BankingCode;
            obj.BirthDate = dto.BirthDate.ToNullableDateTime();
            obj.CellPhone = dto.Tel_Móvil;
            //obj.ClientCreditCards = dto.CreditCards.Select(cc => ClientCreditCardDtoMapper.GetObject(cc)).ToList();
            obj.CollectionTimeRange = dto.CollectionTimeRange;
            obj.Cuit = dto.Cuit;
            obj.Document = dto.DNI;
            obj.DocumentType = IdTypeDtoMapper.ToEnum(dto.DocumentTypes);
            obj.FirstName = dto.Nombre;
            obj.IngresosBrutos = dto.IngresosBrutos;
            obj.IsSmoker = dto.IsSmoker;
            obj.IVA = IvaDtoMapper.ToEnum(dto.Iva);
            obj.LastName = dto.Apellido;
            obj.Mail = dto.Mail;
            obj.MaritalStatus = MaritalStatusDtoMapper.ToEnum(dto.MaritalStatus);
            obj.Notes = dto.Notes;
            obj.Occupation = dto.Occupation;
            obj.Sex = SexDtoMapper.ToEnum(dto.Sex);
            return obj;
        }

        public static ClientIndexDto GetIndexDto(Client obj)
        {
            var dto = new ClientIndexDto();
            dto.Nombre_Completo = obj.LastName + ", " + obj.FirstName;
            dto.Nombre = obj.FirstName;
            dto.Id = (int)obj.Id;
            dto.Apellido = obj.LastName;
            dto.Mail = obj.Mail;
            dto.Tel_Móvil = obj.CellPhone;
            dto.Dni = obj.Document;
            dto.PolicyCount = obj.Policy.Count();
            dto.BirthDate = obj.BirthDate.ToString();
            dto.CUIT = obj.Cuit;
            return dto;
        }

        public static ClientFullDto GetDto(Client obj)
        {
            var date = new DateTime(1753, 1, 1).ToShortDateString();
            var dto = new ClientFullDto();
            dto.Id = (int)obj.Id;
            SetHomeAddress(dto, obj);
            SetCollectionAddress(dto, obj);
            dto.BankingCode = obj.BankingCode;
            dto.BirthDate = obj.BirthDate == null ? date : obj.BirthDate.Value.ToShortDateString();
            dto.Tel_Móvil = obj.CellPhone;
            //dto.CreditCards = obj.ClientCreditCards.Select(ccc => ClientCreditCardDtoMapper.GetInformationDto(ccc));
            dto.CollectionTimeRange = obj.CollectionTimeRange;
            dto.Cuit = obj.Cuit;
            dto.DNI = obj.Document;
            dto.DocumentTypes = IdTypeDtoMapper.ToString(obj.DocumentType);
            dto.Nombre = obj.FirstName;
            dto.Occupation = obj.Occupation;
            dto.IngresosBrutos = obj.IngresosBrutos;
            dto.IsSmoker = obj.IsSmoker;
            dto.Iva = IvaDtoMapper.ToString(obj.IVA);
            dto.Apellido = obj.LastName;
            dto.Mail = obj.Mail;
            dto.MaritalStatus = MaritalStatusDtoMapper.ToString(obj.MaritalStatus);
            dto.Notes = obj.Notes;
            dto.Sex = SexDtoMapper.ToString(obj.Sex);
            return dto;
        }

        private static void SetCollectionAddress(ClientFullDto dto, Client obj)
        {
            var collectionAddress = obj.Addresses.FirstOrDefault(x => x.AddressType == AddressType.Collection);
            if (collectionAddress != null)
            {
                dto.CollectionAddressId = (int)collectionAddress.Id;
                dto.CollectionAppartment = collectionAddress.Appartment;
                dto.CollectionFloor = collectionAddress.Floor;
                dto.CollectionLocalityId = (int?)collectionAddress.LocalityId ?? default(int);
                dto.CollectionDistrictId = (int)collectionAddress.Locality.DistrictId;
                dto.CollectionProvinceId = (int)collectionAddress.Locality.District.ProvinceId;
                dto.CollectionNumber = collectionAddress.Number;
                dto.CollectionPhone = collectionAddress.Phone;
                dto.CollectionPostalCode = collectionAddress.PostalCode;
                dto.CollectionStreet = collectionAddress.Street;
            }
        }

        private static void SetHomeAddress(ClientFullDto dto, Client obj)
        {
            var homeAddress = obj.Addresses.FirstOrDefault(x => x.AddressType == AddressType.Home);
            if (homeAddress != null)
            {
                dto.HomeAddressId = (int)homeAddress.Id;
                dto.HomeAppartment = homeAddress.Appartment;
                dto.HomeFloor = homeAddress.Floor;
                dto.HomeLocalityId = (int?)homeAddress.LocalityId ?? default(int);
                dto.HomeLocality = homeAddress.Locality.Name;
                dto.HomeDistrictId = (int)homeAddress.Locality.DistrictId;
                dto.HomeProvinceId = (int)homeAddress.Locality.District.ProvinceId;
                dto.HomeNumber = homeAddress.Number;
                dto.HomePhone = homeAddress.Phone;
                dto.HomePostalCode = homeAddress.PostalCode;
                dto.HomeStreet = homeAddress.Street;
            }
        }
    }
}