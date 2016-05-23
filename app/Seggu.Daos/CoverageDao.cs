﻿using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;

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
            return this.Set.Any(c => c.Risks.Any(r=>r.Id == riskId));
        }

        public bool GetByNameId(string name, long id, long riskId)
        {
            var prod = this.Set.FirstOrDefault(p => p.Name == name && p.Risks.Any(r => r.Id == riskId));
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

        public bool GetByNameRisk(string name, long idRisk)
        {
            return this.Set.Any(p => p.Name == name && p.Risks.Any(r => r.Id == idRisk));
        }
    }
}
