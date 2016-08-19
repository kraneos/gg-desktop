using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public sealed class CasualtyTypeDao : IdParseEntityDao<CasualtyType>, ICasualtyTypeDao
    {
        public CasualtyTypeDao()
            : base()
        {
        }

        public override void Update(CasualtyType obj)
        {
            var orig = context.CasualtyTypes.Find(obj.Id);
            Mapper.Map<CasualtyType, CasualtyType>(obj, orig);
            context.SaveChanges();
        }
    }
}
