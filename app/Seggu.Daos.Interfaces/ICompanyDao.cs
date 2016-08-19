using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICompanyDao : IParseIdEntityDao<Company>
    {
        List<Company> GetActive();

        List<Company> GetOrderedActive();

        Company GetById(long guid);

        bool GetByName(string name);
    }
}
