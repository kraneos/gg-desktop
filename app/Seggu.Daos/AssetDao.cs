using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;

namespace Seggu.Daos
{
    public sealed class AssetDao : IdParseEntityDao<Asset> , IAssetDao
    {
        public AssetDao()
            : base()
        {
        }
        public override void Update(Asset obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Assets.Find(obj.Id);
                Mapper.Map<Asset, Asset>(obj, orig);
                context.SaveChanges(); 
            }
        }
    }
}
