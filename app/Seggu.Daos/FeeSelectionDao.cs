using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Data.Entity;
using System.Transactions;

namespace Seggu.Daos
{
    public sealed class FeeSelectionDao : GenericDao<FeeSelection>, IFeeSelectionDao
    {
        public int Save(FeeSelection obj, int id)
        {
            using (var scope = new TransactionScope())
            {
                typeof(FeeSelection).GetProperty("Id").SetValue(obj, id, null);
                var entry = this.container.Entry(obj);
                entry.State = EntityState.Added;
                this.container.SaveChanges();
                scope.Complete();
            }

            return obj.Id;
        }
    }
}
