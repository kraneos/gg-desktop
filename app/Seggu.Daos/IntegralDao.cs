using System;
using System.Collections.Generic;
using System.Linq;                            
using System.Text;
using Seggu.Domain;
using Seggu.Daos.Interfaces;
using System.Data.Entity;
using Seggu.Data;       

namespace Seggu.Daos
{
    public sealed class IntegralDao : IdEntityDao<Integral>, IIntegralDao
    {
        public IntegralDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public void SaveIntegral(Integral newIntegral)
        {
            var dbIntegral = context.Integrals
                                    .Include("Addresses")
                                    //.Include("Coverages")
                                    .Single(c => c.Id == newIntegral.Id) ?? newIntegral;

            var coverages = new List<Coverage>(newIntegral.Coverages).ToList();
            dbIntegral.Coverages.Clear();
            newIntegral.Id = dbIntegral.Id;
            foreach (var dbCover in context.Coverages)
            {
                if (coverages.Any(cov => cov.Id == dbCover.Id))
                {
                    context.Coverages.Attach(dbCover);
                    dbIntegral.Coverages.Add(dbCover);
                }
                //else
                //dbVehicle.Coverages.Remove(dbCover);
            }

            context.Entry(dbIntegral).State = EntityState.Added;
            context.Entry(dbIntegral).CurrentValues.SetValues(newIntegral);
            context.SaveChanges();
        }
    }
}
