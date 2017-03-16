using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public sealed class AssetDao : IdParseEntityDao<Asset> , IAssetDao
    {
        public AssetDao(SegguDataModelContext context)
            : base(context)
        {
        }
        public override void Update(Asset obj)
        {
            var orig = context.Assets.Find(obj.Id);
            Mapper.Map<Asset, Asset>(obj, orig);
            context.SaveChanges();
        }
    }
}
