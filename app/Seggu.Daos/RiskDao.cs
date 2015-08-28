using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class RiskDao : GenericDao<Risk> , IRiskDao
    {
        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }

        public IEnumerable<Risk> GetByCompany(int idCompany)
        {
            return
                from r in this.Set
                where r.CompanyId == idCompany
                orderby r.Name
                select r;
        }

        public IEnumerable<Risk> GetByCompanyWithCoveragePacks(int idCompany)
        {
            return
                from r in this.Set.Include("CoveragesPacks.Coverages")
                where r.CompanyId == idCompany
                orderby r.Name
                select r;
        }


        public bool BetByNameId(string name, int id)
        {
            var prod = this.Set.FirstOrDefault(p => p.Name == name);
            if (prod == null)
            {
                return false;
            }
            else if (prod.Id == id)
            {
                return false;
            }
            return true;
        }
    }
}
