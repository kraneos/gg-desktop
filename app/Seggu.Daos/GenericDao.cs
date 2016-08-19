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

        public GenericDao()
        {
            //this.context = context;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.context.Set<T>();
        }

        public virtual T Get(object id)
        {
            return this.Set.Find(id);
        }

        public virtual void Save(T obj)
        {
            //using (var scope = new TransactionScope())
            //{
                this.Set.Add(obj);
                this.context.SaveChanges();
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

        public virtual void Delete(T obj)
        {
            //using (var scope = new TransactionScope())
            //{
                this.Set.Remove(obj);
                this.context.SaveChanges();
            //    scope.Complete();
            //}
        }

        public void Delete(object id)
        {
            //using (var scope = new TransactionScope())
            //{
                var obj = this.Set.Find(id);
                this.Set.Remove(obj);
                this.context.SaveChanges();
            //    scope.Complete();
            //}
        }

        public virtual void SaveMany(IEnumerable<T> objs)
        {
            //using (var scope = new TransactionScope())
            //{
                this.DoBulkAction(objs, EntityState.Added);
            //    scope.Complete();
            //}
        }

        public virtual void UpdateMany(IEnumerable<T> objs)
        {
            //using (var scope = new TransactionScope())
            //{
                this.DoBulkAction(objs, EntityState.Modified);
            //    scope.Complete();
            //}
        }

        public virtual void DeleteMany(IEnumerable<T> objs)
        {
            //using (var scope = new TransactionScope())
            //{
                this.DoBulkAction(objs, EntityState.Deleted);
            //    scope.Complete();
            //}
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return this.context.Set<T>().Where(predicate);
        }

        private void DoBulkAction(IEnumerable<T> objs, EntityState entityState)
        {
            var count = 100;
            var i = 0;
            var objList = objs.ToList();

            foreach (var obj in objs)
            {

                var entry = this.context.Entry(obj);
                entry.State = entityState;

                //this.DoAction(objList[i], entityState);
                i++;
                if (i % count == 0)
                    this.context.SaveChanges();
            }
            if (i % count != 0)
                this.context.SaveChanges();
        }

        private void DoAction(T obj, EntityState entityState)
        {
            var entry = this.context.Entry(obj);
            entry.State = entityState;
        }

        public SegguDataModelContext GetContainer()
        {
            return this.context;
        }
    }
}
