using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services
{
    public sealed class ContactService : IContactService
    {
        private IContactDao contactDao;

        public ContactService(IContactDao contactDao)
        {
            this.contactDao = contactDao;
        }

        public IEnumerable<ContactDto> GetAll()
        {
            var contacts = this.contactDao.GetAll();
            return contacts.OrderBy(x => x.FirstName).Select(b => ContactDtoMapper.GetDto(b));
        }

        public void Delete(int id)
        {
            try
            {
                var guid = id;
                contactDao.Delete(guid);
            }
            catch (Exception) { throw; }
        }

        public void Create(ContactFullDto contact)
        {
            this.contactDao.Save(ContactDtoMapper.GetObject(contact));
        }

        public void Update(ContactFullDto contact)
        {
            this.contactDao.Update(ContactDtoMapper.GetObject(contact));
        }
    }
}
