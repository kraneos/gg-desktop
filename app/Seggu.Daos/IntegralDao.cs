using System;
using System.Collections.Generic;
using System.Linq;                            
using System.Text;
using Seggu.Domain;
using Seggu.Daos.Interfaces;
using System.Data.Entity;       

namespace Seggu.Daos
{
    public sealed class IntegralDao : GenericDao<Integral>, IIntegralDao
    {
        public void SaveIntegral(Integral newIntegral)
        {
            var dbIntegral = container.Integrals
                                    .Include("Addresses")
                                    //.Include("Coverages")
                                    .Single(c => c.Id == newIntegral.Id) ?? newIntegral;

            var coverages = new List<Coverage>(newIntegral.Coverages).ToList();
            dbIntegral.Coverages.Clear();
            newIntegral.Id = dbIntegral.Id;
            foreach (var dbCover in container.Coverages)
            {
                if (coverages.Any(cov => cov.Id == dbCover.Id))
                {
                    container.Coverages.Attach(dbCover);
                    dbIntegral.Coverages.Add(dbCover);
                }
                //else
                //dbVehicle.Coverages.Remove(dbCover);
            }

            container.Entry(dbIntegral).State = EntityState.Added;
            container.Entry(dbIntegral).CurrentValues.SetValues(newIntegral);
            container.SaveChanges();
        }
    }
}
