using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class AttachedFileDao : IdEntityDao<AttachedFile>, IAttachedFileDao
    {
        public IEnumerable<AttachedFile> GetByPolicyId(long guid)
        {
            return this.Set
                .Where(f => f.PolicyId == guid);
        }

    }
}
