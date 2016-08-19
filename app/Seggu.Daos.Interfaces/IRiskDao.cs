using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IRiskDao : IParseIdEntityDao<Risk>
    {
        bool GetByName(string name);
        List<Risk> GetByCompany(long idCompany);
        List<Risk> GetByCompanyWithCoveragePacks(long idCompany);
        bool GetByNameId(string name, long id);
        List<Risk> GetByCompanyAndRiskType(long id, RiskType riskType);
    }
}
