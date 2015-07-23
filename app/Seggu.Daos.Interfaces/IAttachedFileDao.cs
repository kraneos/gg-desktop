using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IAttachedFileDao : IGenericDao<AttachedFile>
    {
        IEnumerable<AttachedFile> GetByPolicyId(Guid guid);
    }
}
