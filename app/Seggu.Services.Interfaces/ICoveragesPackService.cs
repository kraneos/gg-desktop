using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seggu.Dtos;


namespace Seggu.Services.Interfaces
{
    public interface ICoveragesPackService
    {
        void Create(CoveragesPackDto coveragesPack);
        IEnumerable<CoveragesPackDto> GetAllByRiskId(int riskId);
        IEnumerable<CoveragesPackDto> GetById(int selectedCovPackid);
        int GetPackIdByCoverageId(int id, int riskId);
        void Update(CoveragesPackDto coveragesPack);
        void Delete(int id);
        bool ExistName(string name);
        bool ExistNameRisk(string name, int idRisk);
        bool ExistNameId(string name, int id, int riskId);
        IEnumerable<KeyValueDto> GetAllByRiskIdCombobox(int riskId);
    }
}
