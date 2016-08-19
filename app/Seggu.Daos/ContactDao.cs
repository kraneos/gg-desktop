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
        public ContactDao()
            : base()
        {

        }

        public List<Contact> GetByCompany(int id)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Contacts.Where(x => x.CompanyId == id).ToList();
            }
        }

        public override void Update(Contact obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Contacts.Find(obj.Id);
                Mapper.Map<Contact, Contact>(obj, orig);
                context.SaveChanges();
            }
        }
    }
}
