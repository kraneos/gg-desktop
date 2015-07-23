using Seggu.Daos.Interfaces;
using Seggu.Data;
using System;
using System.Data.Entity;
using System.Transactions;

namespace Seggu.Daos
{
    public sealed class FeeSelectionDao : GenericDao<FeeSelection>, IFeeSelectionDao
    {
        public void Save(FeeSelection obj, Guid id)
        {
            using (var scope = new TransactionScope())
            {
                typeof(FeeSelection).GetProperty("Id").SetValue(obj, id, null);
                var entry = this.container.Entry(obj);
                entry.State = EntityState.Added;
                this.container.SaveChanges();
                scope.Complete();
            }
        }
    }
}
