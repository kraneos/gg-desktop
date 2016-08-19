using Seggu.Daos.Interfaces;
using Seggu.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Seggu.Daos
{
    public abstract class GenericDao<T> : IGenericDao<T> where T : class
    {
        //protected SegguDataModelContext context;
        //{
        //    get
        //    {
        //        return SegguContainer.Instance;
        //    }
        //}

        //public DbSet<T> Set
        //{
        //    get
        //    {
        //        return this.context.Set<T>();
        //    }
        //}

        protected GenericDao()
        {
            //this.context = context;
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Set<T>(); 
            }
        }

        public virtual T Get(object id)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Set<T>().Find(id); 
            }
        }

        public virtual void Save(T obj)
        {
            //using (var scope = new TransactionScope())
            //{
            using (var context = SegguDataModelContext.Create())
            {
                context.Set<T>().Add(obj);
                context.SaveChanges(); 
            }
            //    scope.Complete();
            //}
        }

        public abstract void Update(T obj);

        //public virtual void Update(T obj)
        //{
        //    //using (var scope = new TransactionScope())
        //    //{
        //        var entry = this.context.Entry<T>(obj);
        //        var pkey = (long)typeof(T).GetProperty("Id").GetValue(obj, null);
        //        if (entry.State == EntityState.Detached)
        //        {
        //            T attachedEntity = this.Set.Find(pkey);  // access the key
        //            if (attachedEntity != null)
        //            {
        //                var attachedEntry = this.context.Entry(attachedEntity);
        //                attachedEntry.CurrentValues.SetValues(obj);
        //            }
        //            else
        //                entry.State = EntityState.Modified; // attach the entity
        //        }

        //        this.context.SaveChanges();
        //    //    scope.Complete();
        //    //}
        //}

        public virtual void Delete(object id, T obj)
        {
            //using (var scope = new TransactionScope())
            //{
            using (var context = SegguDataModelContext.Create())
            {
                var innerObj = context.Set<T>().Find(id);
                context.Set<T>().Remove(innerObj);
                context.SaveChanges();
            }
            //    scope.Complete();
            //}
        }

        public void Delete(object id)
        {
            //using (var scope = new TransactionScope())
            //{
            using (var context = SegguDataModelContext.Create())
            {
                var obj = context.Set<T>().Find(id);
                context.Set<T>().Remove(obj);
                context.SaveChanges(); 
            }
            //    scope.Complete();
            //}
        }

        public virtual void SaveMany(IEnumerable<T> objs)
        {
            //using (var scope = new TransactionScope())
            //{
            DoBulkAction(objs, EntityState.Added);
            //    scope.Complete();
            //}
        }

        public virtual void UpdateMany(IEnumerable<T> objs)
        {
            //using (var scope = new TransactionScope())
            //{
            DoBulkAction(objs, EntityState.Modified);
            //    scope.Complete();
            //}
        }

        public virtual void DeleteMany(IEnumerable<T> objs)
        {
            //using (var scope = new TransactionScope())
            //{
            DoBulkAction(objs, EntityState.Deleted);
            //    scope.Complete();
            //}
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Set<T>().Where(predicate);
            }
        }

        private static void DoBulkAction(IEnumerable<T> objs, EntityState entityState)
        {
            using (var context = SegguDataModelContext.Create())
            {
                const int count = 100;
                var i = 0;
                var objList = objs.ToList();

                foreach (var entry in objs.Select(obj => context.Entry(obj)))
                {
                    entry.State = entityState;

                    //this.DoAction(objList[i], entityState);
                    i++;
                    if (i % count == 0)
                        context.SaveChanges();
                }
                if (i % count != 0)
                    context.SaveChanges();
            }
        }

        //private void DoAction(T obj, EntityState entityState)
        //{
        //    var entry = this.context.Entry(obj);
        //    entry.State = entityState;
        //}

        //public SegguDataModelContext GetContainer()
        //{
        //    return this.context;
        //}
    }
}
