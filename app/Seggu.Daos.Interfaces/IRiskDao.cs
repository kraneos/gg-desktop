using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IRiskDao : IGenericDao<Risk>
    {
        bool GetByName(string name);
        IEnumerable<Risk> GetByCompany(int idCompany);
        IEnumerable<Risk> GetByCompanyWithCoveragePacks(int idCompany);
        bool BetByNameId(string name, int id);
    }
}
