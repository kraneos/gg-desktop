using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class CompanyDao : IdEntityDao<Company>, ICompanyDao
    {
        public IEnumerable<Company> GetActive()
        {
            return this.container.Companies.Where(c => c.Active);
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
            return from c in this.container.Companies
                   where c.Active
                   orderby c.Name
                   select c;
        }
    }
}
