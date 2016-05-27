using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class CompanyDao : IdParseEntityDao<Company>, ICompanyDao
    {
        public CompanyDao(SegguDataModelContext context)
            : base(context)
        {
        }

        public IEnumerable<Company> GetActive()
        {
            return this.context.Companies.Where(c => c.Active);
        }

        public Company GetByFullId(int id)
        {
            return this.Set
                .Include("Contacts")
                .Include("ProducerCodes.Producer")
                .Include("Risks")
                .First(c => c.Id == id);
        }

        public Company GetById(long guid)
        {
            return this.Set.First(c => c.Id == guid);
        }


        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }

        public IEnumerable<Company> GetOrderedActive()
        {
            return from c in this.context.Companies
                   where c.Active
                   orderby c.Name
                   select c;
        }
    }
}
