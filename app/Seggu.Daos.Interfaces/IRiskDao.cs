using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IRiskDao : IGenericDao<Risk>
    {
        bool GetByName(string name);
        IEnumerable<Risk> GetByCompany(Guid idCompany);
        bool BetByNameId(string name, Guid id);
    }
}
