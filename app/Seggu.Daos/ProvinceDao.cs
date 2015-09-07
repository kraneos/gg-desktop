using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public sealed class ProvinceDao : IdEntityDao<Province>, IProvinceDao
    {
        public ProvinceDao(SegguDataModelContext context)
            : base(context)
        {

        }

    }
}
