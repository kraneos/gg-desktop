using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class CompanyDao : IdParseEntityDao<Company>, ICompanyDao
    {
        public CompanyDao()
            : base()
        {
        }

        public IEnumerable<Company> GetActive()
        {
            return this.context.Companies.Where(c => c.Active);
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

        public override void Update(Company obj)
        {
            var orig = context.Companies.Find(obj.Id);
            Mapper.Map<Company, Company>(obj, orig);
            context.SaveChanges();
        }
    }
}
