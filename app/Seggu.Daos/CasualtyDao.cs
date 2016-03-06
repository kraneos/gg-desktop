using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class CasualtyDao : IdParseEntityDao<Casualty>, ICasualtyDao
    {
        public CasualtyDao(SegguDataModelContext context)
            : base(context)
        {
        }

        public IEnumerable<Casualty> GetByPolicyId(long guid)
        {
            return this.Set
                .Where(c => c.PolicyId == guid);
        }
    }
}
