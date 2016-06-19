using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Data.Entity;
using System.Transactions;

namespace Seggu.Daos
{
    public sealed class LiquidationDao : IdParseEntityDao<Liquidation>, ILiquidationDao
    {
        public LiquidationDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public void Create(Liquidation obj, long id)
        {
            //using (var scope = new TransactionScope())
            //{
                //typeof(Liquidation).GetProperty("Id").SetValue(obj, id, null);
                var entry = this.context.Entry(obj);
                entry.State = EntityState.Added;
                this.context.SaveChanges();
            //    scope.Complete();
            //}
        }

    }
}
