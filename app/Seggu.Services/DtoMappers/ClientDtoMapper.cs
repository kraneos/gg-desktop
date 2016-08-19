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
            var obj = new Client
            {
                Id = dto.Id,
                BankingCode = dto.BankingCode,
                BirthDate = dto.BirthDate.ToNullableDateTime(),
                CellPhone = dto.Tel_Móvil,
                CollectionTimeRange = dto.CollectionTimeRange,
                Cuit = dto.Cuit,
                Document = dto.DNI,
                DocumentType = IdTypeDtoMapper.ToEnum(dto.DocumentTypes),
                FirstName = dto.Nombre,
                IngresosBrutos = dto.IngresosBrutos,
                IsSmoker = dto.IsSmoker,
                IVA = IvaDtoMapper.ToEnum(dto.Iva),
                LastName = dto.Apellido,
                Mail = dto.Mail,
                MaritalStatus = MaritalStatusDtoMapper.ToEnum(dto.MaritalStatus),
                Notes = dto.Notes,
                Occupation = dto.Occupation,
                Sex = SexDtoMapper.ToEnum(dto.Sex)
            };

            //obj.ClientCreditCards = dto.CreditCards.Select(cc => ClientCreditCardDtoMapper.GetObject(cc)).ToList();
            return obj;
        }

        public static ClientIndexDto GetIndexDto(Client obj)
        {
            var dto = new ClientIndexDto
            {
                Nombre_Completo = obj.LastName + ", " + obj.FirstName,
                Nombre = obj.FirstName,
                Id = (int)obj.Id,
                Apellido = obj.LastName,
                Mail = obj.Mail,
                Tel_Móvil = obj.CellPhone,
                Dni = obj.Document,
                //PolicyCount = policies.Count,
                BirthDate = obj.BirthDate.ToString(),
                CUIT = obj.Cuit
            };
            return dto;
        }

        public static ClientFullDto GetDto(Client obj)
        {
            var date = new DateTime(1753, 1, 1).ToShortDateString();
            var dto = new ClientFullDto { Id = (int)obj.Id };
            SetHomeAddress(dto, obj);
            SetCollectionAddress(dto, obj);
            dto.BankingCode = obj.BankingCode;
            dto.BirthDate = obj.BirthDate?.ToShortDateString() ?? date;
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
            if (collectionAddress == null) return;
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

        private static void SetHomeAddress(ClientFullDto dto, Client obj)
        {
            var homeAddress = obj.Addresses.FirstOrDefault(x => x.AddressType == AddressType.Home);
            if (homeAddress == null) return;
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