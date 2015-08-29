using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICompanyDao : IIdEntityDao<Company>
    {
        IEnumerable<Company> GetActive();

        IEnumerable<Company> GetOrderedActive();

        Company GetById(long guid);

        bool GetByName(string name);
    }
}
