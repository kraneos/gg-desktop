using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public sealed class AccessoryTypeDao : IdEntityDao<AccessoryType>, IAccessoryTypeDao
    {
        public AccessoryTypeDao(SegguDataModelContext context)
            : base(context)
        {
        }

    }
}
