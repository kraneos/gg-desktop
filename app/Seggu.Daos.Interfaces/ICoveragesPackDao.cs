using Seggu.Domain;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICoveragesPackDao : IParseIdEntityDao<CoveragesPack>
    {
        void UpdateCoveragesPack(CoveragesPack coveragesPack);
        List<CoveragesPack> GetByRiskId(long riskId);
        bool GetByName(string name);
        bool GetByNameRisk(string name, long idRisk);
        bool GetByNameId(string name, long id, long riskId);
        bool HasRiskPackege(long idRisk);
    }
}
