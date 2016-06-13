using System;
using System.Collections.Generic;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class ContactDao : IdParseEntityDao<Contact>, IContactDao
    {
        public ContactDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public IEnumerable<Contact> GetByCompany(int id)
        {
            return context.Contacts.Where(x => x.CompanyId == id);
        }
    }
}
