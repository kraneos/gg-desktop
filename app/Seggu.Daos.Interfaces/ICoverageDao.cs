using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICoverageDao: IParseIdEntityDao<Coverage>
    {
        bool GetByName(string name);
        bool GetByNameId(string name, long id, long riskId);
        bool RiskHasCoverage(long riskId);
        bool GetByNameRisk(string name, long idRisk);
        
    }
}
