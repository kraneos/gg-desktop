using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface ICoverageService
    {
        IEnumerable<CoverageDto> GetAllByRiskId(int Id);
        IEnumerable<CoverageDto> GetAll();
        void Delete(int id);
        void DeleteMany(IEnumerable<CoverageDto> coverages);
        void Update(CoverageDto coverage);
        void Save(CoverageDto coverage);
        bool ExistName(string name);
        bool ExistNameRisk(string name, int idRisk);
        bool ExistNameId(string name, int id, int riskId);
    }
}
