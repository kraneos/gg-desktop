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
        public CasualtyDao(SegguDataModelContext context)
            : base(context)
        {
        }

        public IEnumerable<Casualty> GetByPolicyId(long guid)
        {
            return this.Set
                .Where(c => c.PolicyId == guid);
        }

        public override void Update(Casualty obj)
        {
            var orig = context.Casualties.Find(obj.Id);
            Mapper.Map<Casualty, Casualty>(obj, orig);
            context.SaveChanges();
        }
    }
}
