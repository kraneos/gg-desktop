using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IRiskService
    {
        void Delete(string id);

        IEnumerable<RiskCompanyDto> GetByCompany(string Id);

        void Create(RiskCompanyDto risk);

        void Update(RiskCompanyDto risk);
        bool ExistName(string name);
        bool ExistNameId(string name, string id);
        bool HasCoverages(string id);
        bool HasPackages(string id);

    }
}
