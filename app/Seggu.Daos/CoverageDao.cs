using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;

namespace Seggu.Daos
{
    public sealed class CoverageDao : GenericDao<Coverage>, ICoverageDao
    {
        public bool GetByName(string name)
        {
            return this.Set.Any(c => c.Name == name);
        }



        public bool RiskHasCoverage(int riskId)
        {
            return this.Set.Any(c => c.RiskId == riskId);
        }


        public bool BetByNameId(string name, int id, int riskId)
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


        public bool BetByNameRisk(string name, int idRisk)
        {
            return this.Set.Any(p => p.Name == name && p.RiskId == idRisk);
        }
    }
}
