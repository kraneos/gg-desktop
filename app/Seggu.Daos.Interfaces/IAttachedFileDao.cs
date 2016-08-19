using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IAttachedFileDao : IParseIdEntityDao<AttachedFile>
    {
        List<AttachedFile> GetByPolicyId(long guid);
    }
}
