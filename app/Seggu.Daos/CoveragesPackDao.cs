using Seggu.Daos.Interfaces;
using Seggu.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace Seggu.Daos
{
    public sealed class CoveragesPackDao : GenericDao<CoveragesPack>, ICoveragesPackDao
    {
        public IEnumerable<CoveragesPack> GetByRiskId(Guid riskId)
        {
            return this.container.Set<CoveragesPack>().Include("Coverages").Where(x => x.RiskId == riskId);
        }
        public void UpdateCoveragesPack(CoveragesPack coveragesPack)
        {
            var coverages = new List<Coverage>(coveragesPack.Coverages).ToList();
            var newCoveragesPack = container.CoveragesPacks
                                    .Include("Coverages")
                                    .FirstOrDefault(c => c.Id == coveragesPack.Id) ?? coveragesPack;

            newCoveragesPack.Coverages.Clear();
            container.Entry(newCoveragesPack).State = EntityState.Modified;

            coveragesPack.Id = newCoveragesPack.Id;
            container.Entry(newCoveragesPack).CurrentValues.SetValues(coveragesPack);

            foreach (var c in container.Coverages)
            {
                if (coverages.Any(cpack => cpack.Id == c.Id))
                {
                    container.Coverages.Attach(c);
                    newCoveragesPack.Coverages.Add(c);
                }
                else
                    newCoveragesPack.Coverages.Remove(c);
            }
            container.SaveChanges();
        }


        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }


        public bool HasRiskPackege(Guid idRisk)
        {
            return this.Set.Any(c => c.RiskId == idRisk);
        }


        public bool BetByNameRisk(string name, Guid idRisk)
        {
            return this.Set.Any(p => p.Name == name && p.RiskId == idRisk);
        }


        public bool BetByNameId(string name, Guid id, Guid riskId)
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
    }
}
