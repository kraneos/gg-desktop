using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICasualtyDao : IGenericDao<Casualty>
    {
        IEnumerable<Casualty> GetByPolicyId(Guid guid);
    }
}
