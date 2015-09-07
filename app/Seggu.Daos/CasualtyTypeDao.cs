using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public sealed class CasualtyTypeDao : IdEntityDao<CasualtyType>, ICasualtyTypeDao
    {
        public CasualtyTypeDao(SegguDataModelContext context)
            : base(context)
        {
        }

    }
}
