using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;

namespace Seggu.Daos
{
    public sealed class PolicyDao : IdEntityDao<Policy>, IPolicyDao
    {
        private IVehicleDao vehicleDao;
        private IEmployeeDao employeeDao;
        private IIntegralDao integralDao;
        public PolicyDao(IVehicleDao vehicleDao, IEmployeeDao employeeDao, IIntegralDao integralDao)
        {
            this.vehicleDao = vehicleDao;
            this.employeeDao = employeeDao;
            this.integralDao = integralDao;
        }

        public IEnumerable<Policy> GetValidsByClient(long clientId)
        {
            return
                from p in this.Set.OrderBy(p => p.EndDate)
                where
                    p.ClientId == clientId
                    && p.EndDate >= DateTime.Today
                    && p.IsAnnulled == false
                    && p.IsRemoved == false
                select p;
        }
        public IEnumerable<Policy> GetNotValidsByClient(long clientId)
        {
            return
                from p in this.Set
                where
                    p.ClientId == clientId && p.IsAnnulled == true
                    || p.ClientId == clientId && p.IsRemoved == true
                    || p.ClientId == clientId && p.EndDate < DateTime.Today
                select p;
        }
        public IEnumerable<Policy> GetByVehiclePlate(string plate)
        {
            return
            from p in this.Set
            join v in this.container.Vehicles
            on p.Id equals v.PolicyId
            where v.Plate == plate
            select p;
        }
        public IEnumerable<Policy> GetByPolicyNumber(string polNum)
        {
            return
                from p in this.Set
                where p.Number.StartsWith(polNum)
                select p;
        }
        public void Edit(Policy newPolicy)
        {
            Policy dbPolicy = new Policy();
            if (newPolicy.Vehicles != null)
            {
                dbPolicy = container.Policies
                                    .Include("Vehicles.Coverages")
                                    .Include(x => x.Fees)
                                    .Single(c => c.Id == newPolicy.Id);
                UpdatePolicyVehicles(newPolicy, dbPolicy);
            }
            else if (newPolicy.Employees != null)
            {
                dbPolicy = container.Policies
                                    .Include("Employees.Coverages")
                                    .Include(x => x.Fees)
                                    .Single(c => c.Id == newPolicy.Id);
                UpdatePolicyEmployees(newPolicy, dbPolicy);
            }
            else if (newPolicy.Integrals != null)
            {
                dbPolicy = container.Policies
                                    .Include("Integrals.Coverages")
                                    .Include(x => x.Fees)
                                    .Single(c => c.Id == newPolicy.Id);
                UpdatePolicyIntegral(newPolicy, dbPolicy);

            }
            UpdateFees(newPolicy);
            container.Entry(dbPolicy).State = EntityState.Modified;
            container.Entry(dbPolicy).CurrentValues.SetValues(newPolicy);
            container.SaveChanges();
        }
        private void UpdatePolicyVehicles(Policy newPolicy, Policy dbPolicy)
        {
            var vehiclesToRemove = new List<Vehicle>();
            foreach (var dbVehicle in dbPolicy.Vehicles.ToList())
                if (!newPolicy.Vehicles.Any(s => s.Id == dbVehicle.Id))
                    vehiclesToRemove.Add(dbVehicle);

            container.Vehicles.RemoveRange(vehiclesToRemove);
            foreach (var newVehicle in newPolicy.Vehicles)
            {
                var dbVehicle = dbPolicy.Vehicles.SingleOrDefault(s => s.Id == newVehicle.Id);
                if (dbVehicle != null)
                {
                    var coveragesToRemove = new List<Coverage>();
                    var coveragesNotToAdd = new List<Coverage>();
                    container.Entry(dbVehicle).CurrentValues.SetValues(newVehicle);
                    foreach (var dbCoverage in dbVehicle.Coverages)
                        if (newVehicle.Coverages.Any(x => x.Id == dbCoverage.Id))
                        {
                            var newCoverage = newVehicle.Coverages.First(x => x.Id == dbCoverage.Id);
                            coveragesNotToAdd.Add(newCoverage);
                        }
                        else
                            coveragesToRemove.Add(dbCoverage);
                    foreach (var newCoverage in newVehicle.Coverages)
                        if (!coveragesNotToAdd.Any(x => x.Id == newCoverage.Id))
                        {
                            var dbCoverage = container.Coverages.Single(x => x.Id == newCoverage.Id);
                            dbVehicle.Coverages.Add(dbCoverage);
                        }
                    foreach (var coverageToRemove in coveragesToRemove)
                        dbVehicle.Coverages.Remove(coverageToRemove);
                }
                else
                    this.vehicleDao.SaveVehicle(newVehicle);
            }
        }
        private void UpdatePolicyEmployees(Policy newPolicy, Policy dbPolicy)
        {
            var employeesToRemove = new List<Employee>();
            foreach (var dbEmployee in dbPolicy.Employees.ToList())
                if (!newPolicy.Employees.Any(s => s.Id == dbEmployee.Id))
                    employeesToRemove.Add(dbEmployee);

            container.Employees.RemoveRange(employeesToRemove);

            foreach (var newEmployee in newPolicy.Employees)
            {
                var dbEmployee = dbPolicy.Employees.SingleOrDefault(s => s.Id == newEmployee.Id);
                if (dbEmployee != null)
                {
                    var coveragesToRemove = new List<Coverage>();
                    var coveragesNotToAdd = new List<Coverage>();
                    container.Entry(dbEmployee).CurrentValues.SetValues(newEmployee);
                    foreach (var dbCoverage in dbEmployee.Coverages)
                        if (newEmployee.Coverages.Any(x => x.Id == dbCoverage.Id))
                        {
                            var newCoverage = newEmployee.Coverages.First(x => x.Id == dbCoverage.Id);
                            coveragesNotToAdd.Add(newCoverage);
                        }
                        else
                            coveragesToRemove.Add(dbCoverage);

                    foreach (var newCoverage in newEmployee.Coverages)
                        if (!coveragesNotToAdd.Any(x => x.Id == newCoverage.Id))
                        {
                            var dbCoverage = container.Coverages.Single(x => x.Id == newCoverage.Id);
                            dbEmployee.Coverages.Add(dbCoverage);
                        }
                    foreach (var coverageToRemove in coveragesToRemove)
                        dbEmployee.Coverages.Remove(coverageToRemove);
                }
                else
                    this.employeeDao.SaveEmployee(newEmployee);
            }
        }
        private void UpdatePolicyIntegral(Policy newPolicy, Policy dbPolicy)
        {
            var integralsToRemove = new List<Integral>();
            foreach (var dbIntegral in dbPolicy.Integrals.ToList())
                if (!newPolicy.Integrals.Any(s => s.Id == dbIntegral.Id))
                    integralsToRemove.Add(dbIntegral);

            container.Integrals.RemoveRange(integralsToRemove);

            foreach (var newIntegral in newPolicy.Integrals)
            {
                var dbIntegral = dbPolicy.Integrals.SingleOrDefault(s => s.Id == newIntegral.Id);
                if (dbIntegral != null)
                {
                    var coveragesToRemove = new List<Coverage>();
                    var coveragesNotToAdd = new List<Coverage>();
                    container.Entry(dbIntegral).CurrentValues.SetValues(newIntegral);
                    container.Entry(dbIntegral.Address).CurrentValues.SetValues(newIntegral.Address);
                    foreach (var dbCoverage in dbIntegral.Coverages)
                        if (newIntegral.Coverages.Any(x => x.Id == dbCoverage.Id))
                        {
                            var newCoverage = newIntegral.Coverages.First(x => x.Id == dbCoverage.Id);
                            coveragesNotToAdd.Add(newCoverage);
                        }
                        else
                            coveragesToRemove.Add(dbCoverage);

                    foreach (var newCoverage in newIntegral.Coverages)
                        if (!coveragesNotToAdd.Any(x => x.Id == newCoverage.Id))
                        {
                            var dbCoverage = container.Coverages.Single(x => x.Id == newCoverage.Id);
                            dbIntegral.Coverages.Add(dbCoverage);
                        }
                    foreach (var coverageToRemove in coveragesToRemove)
                        dbIntegral.Coverages.Remove(coverageToRemove);
                }
                else
                    this.integralDao.SaveIntegral(newIntegral);
            }
        }
        private void UpdateFees(Policy policy)
        {
            foreach (var fee in policy.Fees)
            {
                //if (fee.Id == Guid.Empty)
                //fee.Id = Guid.NewGuid();
                fee.PolicyId = policy.Id;
            }

            var feesToDelete = this.container.Fees.Where(f => f.PolicyId == policy.Id);
            this.container.Fees.RemoveRange(feesToDelete);

            this.container.Fees.AddRange(policy.Fees);
        }
    }
}
