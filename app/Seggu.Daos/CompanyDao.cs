using Seggu.Daos.Interfaces;
using Seggu.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class CompanyDao : GenericDao<Company>, ICompanyDao
    {
        public IEnumerable<Company> GetIndex()
        {
            return this.container.Companies.Where(c => c.Active);
        }

        public Company GetById(Guid guid)
        {
            return this.Set.First(c => c.Id == guid);
        }


        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }
    }
}
