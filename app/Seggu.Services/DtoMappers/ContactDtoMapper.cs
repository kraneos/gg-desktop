using Seggu.Data;
using Seggu.Dtos;
using System;

namespace Seggu.Services.DtoMappers
{
    public static class ContactDtoMapper
    {
        public static ContactDto GetDto(Contact c)
        {
            var dto = new ContactDto();
            dto.Id = c.Id.ToString();
            dto.FirstName = c.FirstName;
            dto.LastName = c.LastName;
            dto.Bussiness = c.Company != null ? c.Company.Name : c.Bussiness;
            dto.Mail = c.Mail;
            dto.Phone = c.Phone;
            dto.Notes = c.Notes;
            dto.CompanyId = c.CompanyId.ToString();
            return dto;
        }

        public static Contact GetObject(ContactDto contact)
        {
            var c = new Contact();
            c.Id = new Guid(contact.Id);
            c.FirstName = contact.FirstName;
            c.LastName = contact.LastName;
            return c;
        }

        public static Contact GetObject(ContactFullDto contact)
        {
            var c = new Contact();
            c.Id = string.IsNullOrEmpty(contact.Id) ? Guid.Empty : new Guid(contact.Id);
            c.Bussiness = contact.Bussiness;
            c.CompanyId = string.IsNullOrEmpty(contact.CompanyId) ? null : (Guid?)new Guid(contact.CompanyId);
            c.FirstName = contact.FirstName;
            c.LastName = contact.LastName;
            c.Mail = contact.Mail;
            c.Notes = contact.Notes;
            c.Phone = contact.Phone;
            return c;
        }
    }
}
