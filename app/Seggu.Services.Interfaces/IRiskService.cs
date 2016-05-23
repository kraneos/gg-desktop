using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IRiskService
    {
        void Delete(int id);

        IEnumerable<RiskCompanyDto> GetByCompany(int Id);

        void Create(RiskCompanyDto risk);

        void Update(RiskCompanyDto risk);
        bool ExistName(string name);
        bool ExistNameId(string name, int id);
        bool HasCoverages(int id);
        IEnumerable<RiskItemDto> GetByCompanyCombobox(int companyId);
    }
}
