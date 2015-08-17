using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICompanyDao : IGenericDao<Company>
    {
        IEnumerable<Company> GetActive();

        IEnumerable<Company> GetOrderedActive();

        Company GetById(Guid guid);

        bool GetByName(string name);
    }
}
