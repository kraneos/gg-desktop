using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICoverageDao: IGenericDao<Coverage>
    {
        bool GetByName(string name);
        bool BetByNameId(string name, Guid id, Guid riskId);
        bool RiskHasCoverage(Guid riskId);
        bool BetByNameRisk(string name, Guid idRisk);
        
    }
}
