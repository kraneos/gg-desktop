using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Daos
{
    public class ImplementedVersionDao : IdEntityDao<ImplementedVersion>, IImplementedVersionDao
    {
        public ImplementedVersionDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public bool Exists(string versionName)
        {
            return this.Set.Any(v => v.Name == versionName);
        }
    }
}
