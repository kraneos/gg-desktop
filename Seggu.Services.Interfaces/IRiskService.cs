using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IRiskService
    {
        void Delete(long id);

        IEnumerable<RiskCompanyDto> GetByCompany(long Id);

        void Create(RiskCompanyDto risk);

        void Update(RiskCompanyDto risk);
        bool ExistName(string name);
        bool ExistNameId(string name, long id);
        bool HasCoverages(long id);
        bool HasPackages(long id);
        IEnumerable<RiskItemDto> GetByCompanyCombobox(long companyId);
        IEnumerable<RiskCompanyDto> GetByCompanyAndRiskType(long id, string riskType);
    }
}
