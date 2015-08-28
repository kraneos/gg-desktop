using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class CasualtyDao : GenericDao<Casualty>, ICasualtyDao
    {
        public IEnumerable<Casualty> GetByPolicyId(int guid)
        {
            return this.Set
                .Where(c => c.PolicyId == guid);
        }
    }
}
