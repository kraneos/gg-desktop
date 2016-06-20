using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public sealed class AccessoryTypeDao : IdParseEntityDao<AccessoryType>, IAccessoryTypeDao
    {
        public AccessoryTypeDao(SegguDataModelContext context)
            : base(context)
        {
        }

        public override void Update(AccessoryType obj)
        {

        }
    }
}
