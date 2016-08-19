using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class IntegralDao : IdParseEntityDao<Integral>, IIntegralDao
    {
        public IntegralDao()
            : base()
        {

        }

        public void SaveIntegral(Integral newIntegral)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var dbIntegral = context.Integrals
                                .Include("Addresses")
                                .Single(c => c.Id == newIntegral.Id) ?? newIntegral;

                var coverages = new List<Coverage>(newIntegral.Coverages).ToList();
                dbIntegral.Coverages.Clear();
                newIntegral.Id = dbIntegral.Id;
                foreach (var dbCover in context.Coverages.Where(dbCover => coverages.Any(cov => cov.Id == dbCover.Id)))
                {
                    context.Coverages.Attach(dbCover);
                    dbIntegral.Coverages.Add(dbCover);
                }

                //context.Entry(dbIntegral).State = EntityState.Added;
                //context.Entry(dbIntegral).CurrentValues.SetValues(newIntegral);
                context.Integrals.Add(dbIntegral);

                context.SaveChanges(); 
            }
        }

        public override void Update(Integral obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Integrals.Find(obj.Id);
                Mapper.Map<Integral, Integral>(obj, orig);
                context.SaveChanges(); 
            }
        }
    }
}
