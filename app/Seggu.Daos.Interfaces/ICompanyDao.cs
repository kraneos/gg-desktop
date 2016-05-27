using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICompanyDao : IParseIdEntityDao<Company>
    {
        IEnumerable<Company> GetActive();

        IEnumerable<Company> GetOrderedActive();

        Company GetById(long guid);

        bool GetByName(string name);
        Company GetByFullId(int id);
    }
}
