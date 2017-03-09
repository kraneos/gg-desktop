﻿using Seggu.Domain;
using Seggu.Dtos;
using System;

namespace Seggu.Services.DtoMappers
{
    public static class ContactDtoMapper
    {
        public static ContactDto GetDto(Contact c)
        {
            var dto = new ContactDto();
            dto.Id = (int)c.Id;
            dto.FirstName = c.FirstName;
            dto.LastName = c.LastName;
            dto.Bussiness = c.Company != null ? c.Company.Name : c.Bussiness;
            dto.Mail = c.Mail;
            dto.Phone = c.Phone;
            dto.Notes = c.Notes;
            dto.CompanyId = ((int?)c.CompanyId) ?? default(int);
            return dto;
        }

        public static Contact GetObject(ContactDto contact)
        {
            var c = new Contact();
            c.Id = contact.Id;
            c.FirstName = contact.FirstName;
            c.LastName = contact.LastName;
            return c;
        }

        public static Contact GetObject(ContactFullDto contact)
        {
            var c = new Contact();
            c.Id = contact.Id;
            c.Bussiness = contact.Bussiness;
            c.CompanyId = contact.CompanyId;
            c.FirstName = contact.FirstName;
            c.LastName = contact.LastName;
            c.Mail = contact.Mail;
            c.Notes = contact.Notes;
            c.Phone = contact.Phone;
            return c;
        }
    }
}
