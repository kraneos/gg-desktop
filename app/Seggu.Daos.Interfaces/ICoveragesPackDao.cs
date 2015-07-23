using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICoveragesPackDao : IGenericDao<CoveragesPack>
    {
        void UpdateCoveragesPack(CoveragesPack coveragesPack);
        IEnumerable<CoveragesPack> GetByRiskId(Guid riskId);
        bool GetByName(string name);
        bool BetByNameRisk(string name, Guid idRisk);
        bool BetByNameId(string name, Guid id, Guid riskId);
        bool HasRiskPackege(Guid idRisk);

    }
}
