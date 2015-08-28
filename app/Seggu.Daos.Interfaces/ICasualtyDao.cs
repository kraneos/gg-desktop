using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICasualtyDao : IGenericDao<Casualty>
    {
        IEnumerable<Casualty> GetByPolicyId(int guid);
    }
}
