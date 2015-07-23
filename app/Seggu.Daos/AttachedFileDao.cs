using Seggu.Daos.Interfaces;
using Seggu.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class AttachedFileDao : GenericDao<AttachedFile>, IAttachedFileDao
    {
        public IEnumerable<AttachedFile> GetByPolicyId(Guid guid)
        {
            return this.Set
                .Where(f => f.PolicyId == guid);
        }

    }
}
