using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IAttachedFileDao : IIdEntityDao<AttachedFile>
    {
        IEnumerable<AttachedFile> GetByPolicyId(long guid);
    }
}
