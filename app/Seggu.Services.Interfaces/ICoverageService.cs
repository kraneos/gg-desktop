using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface ICoverageService
    {
        IEnumerable<CoverageDto> GetAllByRiskId(string Id);
        IEnumerable<CoverageDto> GetByPackId(string Id);
        void Delete(string id);
        void DeleteMany(IEnumerable<CoverageDto> coverages);
        void Update(CoverageDto coverage);
        void Save(CoverageDto coverage);
        bool ExistName(string name);
        bool ExistNameRisk(string name, string idRisk);
        bool ExistNameId(string name, string id, string riskId);
    }
}
