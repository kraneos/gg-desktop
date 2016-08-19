using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class CasualtyDao : IdParseEntityDao<Casualty>, ICasualtyDao
    {
        public CasualtyDao()
            : base()
        {
        }

        public List<Casualty> GetByPolicyId(long guid)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Casualties
                    .Where(c => c.PolicyId == guid).ToList();
            }
        }

        public override void Update(Casualty obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Casualties.Find(obj.Id);
                Mapper.Map<Casualty, Casualty>(obj, orig);
                context.SaveChanges();
            }
        }
    }
}
