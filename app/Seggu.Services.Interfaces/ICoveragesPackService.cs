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
        IEnumerable<CoveragesPackDto> GetAllByRiskId(string riskId);
        IEnumerable<CoveragesPackDto> GetById(string selectedCovPackid);
        string GetPackIdByCoverageId(string id, string riskId);
        void Update(CoveragesPackDto coveragesPack);
        void Delete(string id);
        bool ExistName(string name);
        bool ExistNameRisk(string name, string idRisk);
        bool ExistNameId(string name, string id, string riskId);
     }
}
