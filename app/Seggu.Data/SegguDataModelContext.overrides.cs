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
            var entries = this.ChangeTracker
                .Entries()
                .Where(x => parseEntities.Any(y => y == x.Entity.GetType() || (x.Entity.GetType().BaseType == y)))
                .ToList();

            // If Parse Entity
            if (Properties.Settings.Default.SyncWithParse)
            {
                var modifiedEntries = entries.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
                if (modifiedEntries.Any())
                {
                    var setting = this.Settings.OrderByDescending(x => x.Id).FirstOrDefault();
                    if (setting != null)
                    {

                        var parseObjects = modifiedEntries.Select(x => GetParseObject(x, setting));

                        try
                        {
                            ParseObject.SaveAllAsync(parseObjects).Wait();
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
            }

            return base.SaveChanges();
        }

        private ParseObject GetParseObject(DbEntityEntry entry, Setting setting)
        {
            var type = parseEntities.Any(x => x == entry.Entity.GetType()) ? entry.Entity.GetType() : entry.Entity.GetType().BaseType;
            var entityName = type.Name;
            var parseObject = new ParseObject(entityName);
            var properties = type.GetProperties().Where(p =>
                (
                    p.PropertyType == typeof(string) ||
                    !typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
                ) && (
                    p.Name != "Id" && p.Name != "ObjectId" && p.Name != "CreatedAt" && p.Name != "UpdatedAt" && p.Name != "LocallyUpdatedAt"
                ));

            foreach (var prop in properties)
            {
                parseObject[prop.Name] = entry.CurrentValues[prop.Name];
            }
            var ACL = new ParseACL(ParseUser.CurrentUser);
            ACL.PublicReadAccess = false;
            ACL.PublicWriteAccess = false;
            ACL.SetRoleReadAccess(setting.UserRole, true);
            ACL.SetRoleWriteAccess(setting.UserRole, true);

            ACL.SetRoleReadAccess(setting.ClientsRole, true);
            ACL.SetRoleWriteAccess(setting.ClientsRole, true);
            parseObject.ACL = ACL;

            return parseObject;
        }
    }
}
