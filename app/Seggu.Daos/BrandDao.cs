using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Linq;
namespace Seggu.Daos
{
    public sealed class BrandDao : IdParseEntityDao<Brand>, IBrandDao
    {
        public BrandDao()
            : base()
        {
        }

        public bool GetByName(string name)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Brands.Any(c => c.Name == name);
            }
        }

        public override void Update(Brand obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Brands.Find(obj.Id);
                Mapper.Map<Brand, Brand>(obj, orig);
                context.SaveChanges(); 
            }
        }
    }
}
