using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class RiskDao : IdParseEntityDao<Risk> , IRiskDao
    {
        public RiskDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }

        public IEnumerable<Risk> GetByCompany(long idCompany)
        {
            return
                from r in this.Set
                where r.CompanyId == idCompany
                orderby r.Name
                select r;
        }

        public IEnumerable<Risk> GetByCompanyWithCoveragePacks(long idCompany)
        {
            return
                from r in this.Set.Include("CoveragesPacks.Coverages")
                where r.CompanyId == idCompany
                orderby r.Name
                select r;
        }

        public bool BetByNameId(string name, long id)
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

        public IEnumerable<Risk> GetByCompanyAndRiskType(int id, RiskType riskType)
        {
            return context.Risks.Where(r => r.CompanyId == id && r.RiskType == riskType);
        }
    }
}
