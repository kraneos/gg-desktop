using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Daos.Interfaces
{
    public interface IImplementedVersionDao : IIdEntityDao<ImplementedVersion>
    {
        bool Exists(string versionName);
    }
}
