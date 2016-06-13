using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICoverageDao: IParseIdEntityDao<Coverage>
    {
        bool GetByName(string name);
        bool BetByNameId(string name, long id, long riskId);
        bool RiskHasCoverage(long riskId);
        bool BetByNameRisk(string name, long idRisk);
        
    }
}
