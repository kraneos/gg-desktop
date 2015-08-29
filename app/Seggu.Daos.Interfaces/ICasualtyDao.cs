using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICasualtyDao : IIdEntityDao<Casualty>
    {
        IEnumerable<Casualty> GetByPolicyId(long guid);
    }
}
