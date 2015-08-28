using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICoveragesPackDao : IGenericDao<CoveragesPack>
    {
        void UpdateCoveragesPack(CoveragesPack coveragesPack);
        IEnumerable<CoveragesPack> GetByRiskId(int riskId);
        bool GetByName(string name);
        bool BetByNameRisk(string name, int idRisk);
        bool BetByNameId(string name, int id, int riskId);
        bool HasRiskPackege(int idRisk);

    }
}
