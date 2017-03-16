using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICasualtyDao : IParseIdEntityDao<Casualty>
    {
        IEnumerable<Casualty> GetByPolicyId(long guid);
    }
}
