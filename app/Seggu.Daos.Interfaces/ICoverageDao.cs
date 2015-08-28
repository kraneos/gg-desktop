using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICoverageDao: IGenericDao<Coverage>
    {
        bool GetByName(string name);
        bool BetByNameId(string name, int id, int riskId);
        bool RiskHasCoverage(int riskId);
        bool BetByNameRisk(string name, int idRisk);
        
    }
}
