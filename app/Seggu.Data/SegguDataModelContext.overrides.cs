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
using System.Security.Cryptography.X509Certificates;
using AutoMapper;

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
            var entries = this.ChangeTracker
                .Entries()
                .Where(x => parseEntities.Any(y => y == x.Entity.GetType() || (x.Entity.GetType().BaseType == y)))
                .ToList();

            // If Parse Entity
            if (!Properties.Settings.Default.SyncWithParse) return base.SaveChanges();
            {
                var modifiedEntries = entries.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
                if (!modifiedEntries.Any()) return base.SaveChanges();
                {
                    var setting = this.Settings.OrderByDescending(x => x.Id).FirstOrDefault();
                    if (setting == null) return base.SaveChanges();
                    try
                    {
                        foreach (var entry in modifiedEntries)
                        {
                            GetParseObject(entry, setting);
                        }
                    }
                    catch (Exception)
                    {
                        foreach (var modified in modifiedEntries.Where(e => e.State == EntityState.Modified))
                        {
                            modified.CurrentValues["LocallyUpdatedAt"] = DateTime.Now.ToUniversalTime();
                        }
                    }
                }
            }

            return base.SaveChanges();
        }

        private void GetParseObject(DbEntityEntry entry, Setting setting)
        {
            var type = parseEntities.Any(x => x == entry.Entity.GetType()) ? entry.Entity.GetType() : entry.Entity.GetType().BaseType;
            var entityName = type.Name;
            var destType = Mapper.GetAllTypeMaps().First(x => x.SourceType == type && x.DestinationType != type).DestinationType;
            var objId = entry.State == EntityState.Added ? null : entry.GetDatabaseValues()["ObjectId"];
            var isNew = objId == null;
            //var isNew = ((ParseEntity)entry.Entity).ObjectId == null;
            var parseObject = (ParseObject)Mapper.Map(entry.Entity, type, destType, opts =>
            {
                opts.Items["DbContext"] = this;
                opts.Items["Setting"] = setting;
                opts.Items["HttpMethod"] = isNew ? "POST" : "PUT";
                if (!isNew)
                {
                    opts.Items["ObjectId"] = objId;
                }
            });
            if (parseObject == null) return;
            parseObject.SaveAsync().Wait();
            if (!isNew) return;
            entry.CurrentValues["ObjectId"] = parseObject.ObjectId;
            entry.CurrentValues["CreatedAt"] = parseObject.CreatedAt;
            entry.CurrentValues["UpdatedAt"] = parseObject.CreatedAt;
            entry.CurrentValues["LocallyUpdatedAt"] = parseObject.CreatedAt;
        }
    }
}
