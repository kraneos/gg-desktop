using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class EmployeeDao : GenericDao<Employee> , IEmployeeDao
    {
        public IEnumerable<Employee> GetByPolicyId(int policyId)
        {
            return this.Set.Where(x => x.PolicyId == policyId);
        }

        public void SaveEmployee(Employee newVehicle)
        {
            var coverages = new List<Coverage>(newVehicle.Coverages).ToList();
            var dbVehicle = container.Employees
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
