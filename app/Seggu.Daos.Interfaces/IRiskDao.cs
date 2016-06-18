using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IRiskDao : IParseIdEntityDao<Risk>
    {
        bool GetByName(string name);
        IEnumerable<Risk> GetByCompany(long idCompany);
        IEnumerable<Risk> GetByCompanyWithCoveragePacks(long idCompany);
        bool BetByNameId(string name, long id);
        IEnumerable<Risk> GetByCompanyAndRiskType(long id, RiskType riskType);
    }
}
