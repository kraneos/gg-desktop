using Seggu.Domain;
using System;
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
            // If Parse Entity
            if (Properties.Settings.Default.SetUpdatedDate)
            {
                var entries = this.ChangeTracker.Entries().Where(x => parseEntities.Any(y => y == x.Entity.GetType() || (x.Entity.GetType().BaseType == y)));

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

            return base.SaveChanges();
        }
    }
}
