using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Data.Entity;

namespace Seggu.Daos
{
    public sealed class LiquidationDao : IdParseEntityDao<Liquidation>, ILiquidationDao
    {
        public LiquidationDao()
            : base()
        {

        }

        public void Create(Liquidation obj, long id)
        {
            var entry = this.context.Entry(obj);
            entry.State = EntityState.Added;
            this.context.SaveChanges();
        }

        public override void Update(Liquidation obj)
        {
            var orig = context.Liquidations.Find(obj.Id);
            Mapper.Map<Liquidation, Liquidation>(obj, orig);
            context.SaveChanges();
        }
    }
}
