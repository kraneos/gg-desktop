using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICoveragesPackDao : IParseIdEntityDao<CoveragesPack>
    {
        void UpdateCoveragesPack(CoveragesPack coveragesPack);
        IEnumerable<CoveragesPack> GetByRiskId(long riskId);
        bool GetByName(string name);
        bool BetByNameRisk(string name, long idRisk);
        bool BetByNameId(string name, long id, long riskId);
        bool HasRiskPackege(long idRisk);

    }
}
