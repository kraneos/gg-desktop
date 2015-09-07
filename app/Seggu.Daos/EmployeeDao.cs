using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class EmployeeDao : IdEntityDao<Employee>, IEmployeeDao
    {
        public EmployeeDao(SegguDataModelContext context)
            : base(context)
        {

        }

        public IEnumerable<Employee> GetByPolicyId(long policyId)
        {
            return this.Set.Where(x => x.PolicyId == policyId);
        }

        public void SaveEmployee(Employee newVehicle)
        {
            var coverages = new List<Coverage>(newVehicle.Coverages).ToList();
            var dbVehicle = context.Employees
                                    .Include("Coverages")
                                    .FirstOrDefault(c => c.Id == newVehicle.Id) ?? newVehicle;

            dbVehicle.Coverages.Clear();
            context.Entry(dbVehicle).State = EntityState.Added;

            newVehicle.Id = dbVehicle.Id;
            context.Entry(dbVehicle).CurrentValues.SetValues(newVehicle);

            foreach (var dbCover in context.Coverages)
            {
                if (coverages.Any(cov => cov.Id == dbCover.Id))
                {
                    context.Coverages.Attach(dbCover);
                    dbVehicle.Coverages.Add(dbCover);
                }
                //else
                //dbVehicle.Coverages.Remove(dbCover);
            }
            context.SaveChanges();
        }
    }
}
