using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Seggu.Daos
{
    public abstract class IdEntityDao<T> : GenericDao<T>, IIdEntityDao<T> where T : IdEntity
    {
        public new long Save(T obj)
        {
            base.Save(obj);

            return obj.Id;
        }

        public void Delete(long id)
        {
            base.Delete(id);
        }

        public T Find(long id)
        {
            return base.Set.Find(id);
        }
    }
}
