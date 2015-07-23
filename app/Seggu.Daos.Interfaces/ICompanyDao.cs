using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICompanyDao : IGenericDao<Company>
    {
        IEnumerable<Company> GetIndex();

        Company GetById(Guid guid);

        bool GetByName(string name);
    }
}
