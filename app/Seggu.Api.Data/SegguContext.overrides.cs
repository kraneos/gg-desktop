using Seggu.Api.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seggu.Api.Data
{
    public partial class SegguContext
    {
        public override int SaveChanges()
        {
            // If Parse Entity
            var entries = this.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                var parseEntity = (IdEntity)entry.Entity;

                if (entry.State == EntityState.Modified)
                {
                    parseEntity.UpdatedAt = DateTime.Now;
                }
                else if (entry.State == EntityState.Added)
                {
                    parseEntity.CreatedAt = DateTime.Now;
                    parseEntity.UpdatedAt = parseEntity.CreatedAt;
                    parseEntity.Id = Guid.NewGuid();
                }
            }

            return base.SaveChanges();
        }
    }
}
