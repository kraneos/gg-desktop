using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Linq;

namespace Seggu.Daos
{
    public class ImplementedVersionDao : IdEntityDao<ImplementedVersion>, IImplementedVersionDao
    {
        public ImplementedVersionDao()
            : base()
        {

        }

        public bool Exists(string versionName)
        {
            return this.Set.Any(v => v.Name == versionName);
        }

        public override void Update(ImplementedVersion obj)
        {       
        }
    }
}
