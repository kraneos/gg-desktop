using Seggu.Daos.Interfaces;
using Seggu.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class VehicleDao : GenericDao<Vehicle>, IVehicleDao
    {
        public Vehicle GetByPolicyId(Guid policyId)
        {
            return this.Set.First(x => x.PolicyId == policyId);
        }
        public IEnumerable<Vehicle> GetByPlate(string plate)
        {
            return this.Set.Where(x => x.Plate == plate);
        }
        public void SaveVehicle(Vehicle newVehicle)
        {
            var coverages = new List<Coverage>(newVehicle.Coverages).ToList();
            var dbVehicle = container.Vehicles
                                    .Include("Coverages")
                                    .FirstOrDefault(c => c.Id == newVehicle.Id) ?? newVehicle;

            dbVehicle.Coverages.Clear();
            container.Entry(dbVehicle).State = EntityState.Added;

            newVehicle.Id = dbVehicle.Id;
            container.Entry(dbVehicle).CurrentValues.SetValues(newVehicle);

            foreach (var dbCover in container.Coverages)
            {
                if (coverages.Any(cov => cov.Id == dbCover.Id))
                {
                    container.Coverages.Attach(dbCover);
                    dbVehicle.Coverages.Add(dbCover);
                }
                //else
                    //dbVehicle.Coverages.Remove(dbCover);
            }
            container.SaveChanges();
        }
    }
}
