using System.Collections.Generic;
using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class CoverageDao : IdParseEntityDao<Coverage>, ICoverageDao
    {
        public bool GetByName(string name)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Coverages.Any(c => c.Name == name);
            }
        }

        public bool RiskHasCoverage(long riskId)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Coverages.Any(c => c.RiskId == riskId);
            }
        }

        public bool BetByNameId(string name, long id, long riskId)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var prod = context.Coverages.FirstOrDefault(p => p.Name == name && p.RiskId == riskId);
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

        public bool BetByNameRisk(string name, long idRisk)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Coverages.Any(p => p.Name == name && p.RiskId == idRisk);
            }
        }

        public List<Coverage> GetByIds(List<long> ids)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Coverages.Where(x => ids.Contains(x.Id)).ToList();
            }
        }

        public override void Update(Coverage obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Coverages.Find(obj.Id);
                Mapper.Map(obj, orig);
                context.SaveChanges();
            }
        }

    }
}
