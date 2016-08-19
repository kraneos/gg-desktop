using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class RiskDao : IdParseEntityDao<Risk> , IRiskDao
    {
        public RiskDao()
            : base()
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

        public bool GetByNameId(string name, long id)
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

        public IEnumerable<Risk> GetByCompanyAndRiskType(long id, RiskType riskType)
        {
            return context.Risks.Where(r => r.CompanyId == id && r.RiskType == riskType);
        }

        public override void Update(Risk obj)
        {
            var orig = context.Risks.Find(obj.Id);
            Mapper.Map<Risk, Risk>(obj, orig);
            context.SaveChanges();
        }
    }
}
