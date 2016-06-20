using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
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

        public override void Update(Contact obj)
        {
            var orig = context.Contacts.Find(obj.Id);
            Mapper.Map<Contact, Contact>(obj, orig);
            context.SaveChanges();
        }
    }
}
