using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class CoverageDao : IdParseEntityDao<Coverage>, ICoverageDao
    {
        public CoverageDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }

        public bool RiskHasCoverage(long riskId)
        {
            return this.Set.Any(c => c.RiskId == riskId);
        }

        public bool BetByNameId(string name, long id, long riskId)
        {
            var prod = this.Set.FirstOrDefault(p => p.Name == name && p.RiskId == riskId);
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

        public bool BetByNameRisk(string name, long idRisk)
        {
            return this.Set.Any(p => p.Name == name && p.RiskId == idRisk);
        }

        public override void Update(Coverage obj)
        {
            var orig = context.Coverages.Find(obj.Id);
            Mapper.Map<Coverage, Coverage>(obj, orig);
            context.SaveChanges();
        }

    }
}
