using Seggu.Daos.Interfaces;
using Seggu.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace Seggu.Daos
{
    public abstract class GenericDao<T> : IGenericDao<T> where T : class
    {
        protected SegguDataModelContainer container
        {
            get
            {
                return SegguContainer.Instance;
            }
        }

        public DbSet<T> Set
        {
            get
            {
                return this.container.Set<T>();
            }
        }

        public GenericDao()
        {
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.container.Set<T>();
        }

        public virtual T Get(Guid id)
        {
            return this.container.Set<T>().Find(id);
        }

        public virtual void Save(T obj)
        {
            using (var scope = new TransactionScope())
            {
                typeof(T).GetProperty("Id").SetValue(obj, Guid.NewGuid(), null);
                var entry = this.container.Entry(obj);
                entry.State = EntityState.Added;
                //this.Set.Add(obj);
                this.container.SaveChanges();
                scope.Complete();
            }


        }

        public virtual void Update(T obj)
        {
            using (var scope = new TransactionScope())
            {
                var entry = this.container.Entry<T>(obj);
                var pkey = (Guid)typeof(T).GetProperty("Id").GetValue(obj, null);
                if (entry.State == EntityState.Detached)
                {
                    T attachedEntity = this.Set.Find(pkey);  // access the key
                    if (attachedEntity != null)
                    {
                        var attachedEntry = this.container.Entry(attachedEntity);
                        attachedEntry.CurrentValues.SetValues(obj);
                    }
                    else
                        entry.State = EntityState.Modified; // attach the entity
                }
                
                this.container.SaveChanges();
                scope.Complete();
            }
        }

        public virtual void Delete(T obj)
        {
            using (var scope = new TransactionScope())
            {
                var entry = this.container.Entry(obj);
                entry.State = EntityState.Deleted;
                this.container.SaveChanges();
                scope.Complete();
            }
        }

        public void Delete(Guid id)
        {
            using (var scope = new TransactionScope())
            {
                var obj = this.Set.Find(id);
                this.Set.Remove(obj);
                this.container.SaveChanges();
                scope.Complete();
            }
        }

        public virtual void SaveMany(IEnumerable<T> objs)
        {
            using (var scope = new TransactionScope())
            {
                this.DoBulkAction(objs, EntityState.Added);
                scope.Complete();
            }
        }

        public virtual void UpdateMany(IEnumerable<T> objs)
        {
            using (var scope = new TransactionScope())
            {
                this.DoBulkAction(objs, EntityState.Modified);
                scope.Complete();
            }
        }

        public virtual void DeleteMany(IEnumerable<T> objs)
        {
            using (var scope = new TransactionScope())
            {
                this.DoBulkAction(objs, EntityState.Deleted);
                scope.Complete();
            }
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return this.container.Set<T>().Where(predicate);
        }

        private void DoBulkAction(IEnumerable<T> objs, EntityState entityState)
        {
            var count = 100;
            var i = 0;
            var objList = objs.ToList();

            foreach (var obj in objs)
            {

                var entry = this.container.Entry(obj);
                entry.State = entityState;

                //this.DoAction(objList[i], entityState);
                i++;
                if (i % count == 0)
                    this.container.SaveChanges();
            }
            if (i % count != 0)
                this.container.SaveChanges();
        }

        private void DoAction(T obj, EntityState entityState)
        {
            var entry = this.container.Entry(obj);
            entry.State = entityState;
        }

        public SegguDataModelContainer GetContainer()
        {
            return this.container;
        }
    }
}
