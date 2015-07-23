using Seggu.Daos.Interfaces;
using Seggu.Data;
using System;
using System.Data.Entity;
using System.Transactions;

namespace Seggu.Daos
{
    public sealed class LiquidationDao : GenericDao<Liquidation>, ILiquidationDao
    {
        public void Create(Liquidation obj, string id)
        {
            using (var scope = new TransactionScope())
            {
                typeof(Liquidation).GetProperty("Id").SetValue(obj, new Guid(id), null);
                var entry = this.container.Entry(obj);
                entry.State = EntityState.Added;
                this.container.SaveChanges();
                scope.Complete();
            }
        }

    }
}
