using Seggu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.Interfaces
{
    public interface IContactService
    {
        IEnumerable<ContactDto> GetAll();

        void Delete(int id);

        void Create(ContactFullDto contact);

        void Update(ContactFullDto contact);
        IEnumerable<ContactDto> GetByCompanyId(int id);
    }
}
