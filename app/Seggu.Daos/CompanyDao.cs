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

        public List<Company> GetActive()
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Companies.Where(c => c.Active).ToList();
            }
        }

        public Company GetById(long guid)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Companies.First(c => c.Id == guid);
            }
        }

        public bool GetByName(string name)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Companies.Any(c => c.Name == name);
            }
        }

        public List<Company> GetOrderedActive()
        {
            using (var context = SegguDataModelContext.Create())
            {
                return (from c in context.Companies
                        where c.Active
                        orderby c.Name
                        select c).ToList();
            }
        }

        public override void Update(Company obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Companies.Find(obj.Id);
                Mapper.Map<Company, Company>(obj, orig);
                context.SaveChanges();
            }
        }
    }
}
