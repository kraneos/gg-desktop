using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public sealed class AccessoryTypeDao : IdParseEntityDao<AccessoryType>, IAccessoryTypeDao
    {
        public AccessoryTypeDao()
            : base()
        {
        }

        public override void Update(AccessoryType obj)
        {
            var orig = context.AccessoryTypes.Find(obj);
            Mapper.Map<AccessoryType, AccessoryType>(obj, orig);
            context.SaveChanges();
        }
    }
}
