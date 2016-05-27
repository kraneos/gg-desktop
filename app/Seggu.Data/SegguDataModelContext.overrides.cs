using Parse;
using Seggu.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;

namespace Seggu.Data
{
    public partial class SegguDataModelContext
    {
        private static readonly IEnumerable<Type> parseEntities = Assembly.GetAssembly(typeof(Domain.ParseEntity)).GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Domain.ParseEntity))).ToList();

        public void RefreshSet<T>() where T : class
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            objectContext.Refresh(RefreshMode.StoreWins, this.Set<T>());
        }

        public override int SaveChanges()
        {
            var entries = this.ChangeTracker.Entries().Where(x => parseEntities.Any(y => y == x.Entity.GetType() || (x.Entity.GetType().BaseType == y))).ToList();

            // If Parse Entity
            if (Properties.Settings.Default.SetUpdatedDate)
            {
                foreach (var entry in entries)
                {
                    if (entry.State == EntityState.Modified)
                    {
                        var parseEntity = (ParseEntity)entry.Entity;
                        if (parseEntity.ObjectId != null)
                        {
                            parseEntity.LocallyUpdatedAt = DateTime.Now.ToUniversalTime();
                        }
                    }
                }
            }

            var records = base.SaveChanges();

            try
            {
                // Handle Parse
                foreach (var entry in entries.Where(x=>x.State != EntityState.Detached && x.State != EntityState.Unchanged))
                {
                    CreateParse(entry);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return records;
        }

        private void CreateParse(DbEntityEntry entry)
        {
            var entries = this.ChangeTracker.Entries().Where(x => parseEntities.Any(y => y == x.Entity.GetType() || (x.Entity.GetType().BaseType == y))).ToList();
            var entityType = parseEntities.First(y => y == entry.Entity.GetType() || (entry.Entity.GetType().BaseType == y));
            var entityName = entityType.Name;
            var parseObject = new ParseObject(entityName);
            var properties = entityType.GetProperties().Where(p => p.PropertyType == typeof(string) ||
                   !typeof(IEnumerable).IsAssignableFrom(p.PropertyType));

            foreach (var prop in properties)
            {
                parseObject[prop.Name] = entry.CurrentValues[prop.Name];
            }

            parseObject.SaveAsync();
        }
    }
}
