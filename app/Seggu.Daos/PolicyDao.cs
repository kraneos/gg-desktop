using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class PolicyDao : IdParseEntityDao<Policy>, IPolicyDao
    {
        private readonly IVehicleDao vehicleDao;
        private readonly IEmployeeDao employeeDao;
        private readonly IIntegralDao integralDao;
        public PolicyDao(IVehicleDao vehicleDao, IEmployeeDao employeeDao, IIntegralDao integralDao)
            : base()
        {
            this.vehicleDao = vehicleDao;
            this.employeeDao = employeeDao;
            this.integralDao = integralDao;
        }

        public IEnumerable<Policy> GetValidsByClient(long clientId)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return
                from p in context.Policies.OrderBy(p => p.EndDate)
                where
                    p.ClientId == clientId
                    && p.EndDate >= DateTime.Today
                    && p.IsAnnulled == false
                    && p.IsRemoved == false
                orderby p.EndDate descending
                select p;
            }
        }
        public IEnumerable<Policy> GetNotValidsByClient(long clientId)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return
                    from p in context.Policies
                    where
                        p.ClientId == clientId && p.IsAnnulled == true
                        || p.ClientId == clientId && p.IsRemoved == true
                        || p.ClientId == clientId && p.EndDate < DateTime.Today
                    orderby p.EndDate descending
                    select p;
            }
        }
        public IEnumerable<Policy> GetByVehiclePlate(string plate)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return
                    from p in context.Policies
                    join v in context.Vehicles
                    on p.Id equals v.PolicyId
                    where v.Plate == plate
                    select p;
            }
        }
        public IEnumerable<Policy> GetByPolicyNumber(string polNum)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return
                    from p in context.Policies
                    where p.Number.StartsWith(polNum)
                    select p;
            }
        }
        public void Edit(Policy newPolicy)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var dbPolicy = new Policy();
                if (newPolicy.Vehicles != null)
                {
                    dbPolicy = context.Policies
                        .Include("Vehicles.Coverages")
                        .Include(x => x.Fees)
                        .Single(c => c.Id == newPolicy.Id);
                    UpdatePolicyVehicles(newPolicy, dbPolicy);
                }
                else if (newPolicy.Employees != null)
                {
                    dbPolicy = context.Policies
                        .Include("Employees.Coverages")
                        .Include(x => x.Fees)
                        .Single(c => c.Id == newPolicy.Id);
                    UpdatePolicyEmployees(newPolicy, dbPolicy);
                }
                else if (newPolicy.Integrals != null)
                {
                    dbPolicy = context.Policies
                        .Include("Integrals.Coverages")
                        .Include(x => x.Fees)
                        .Single(c => c.Id == newPolicy.Id);
                    UpdatePolicyIntegral(newPolicy, dbPolicy);
                }

                UpdateFees(newPolicy);
                UpdateAttachedFiles(newPolicy);
                Mapper.Map<Policy, Policy>(newPolicy, dbPolicy);

                context.SaveChanges();
            }
        }

        private static void UpdateAttachedFiles(Policy newPolicy)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var existingAttachedFiles = context.AttachedFiles.Where(x => newPolicy.Id == x.PolicyId);
                var nonExistingAttachedFiles = new List<AttachedFile>();

                foreach (var attachedFile in from attachedFile in newPolicy.AttachedFiles let existingAttachedFile = existingAttachedFiles.FirstOrDefault(x => x.FilePath == attachedFile.FilePath) where existingAttachedFile == null select attachedFile)
                {
                    context.AttachedFiles.Add(attachedFile);
                }
            }
        }

        private void UpdatePolicyVehicles(Policy newPolicy, Policy dbPolicy)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var vehiclesToRemove = dbPolicy.Vehicles.ToList().Where(dbVehicle => newPolicy.Vehicles.All(s => s.Id != dbVehicle.Id)).ToList();

                context.Vehicles.RemoveRange(vehiclesToRemove);
                foreach (var newVehicle in newPolicy.Vehicles)
                {
                    var dbVehicle = dbPolicy.Vehicles.SingleOrDefault(s => s.Id == newVehicle.Id);
                    if (dbVehicle != null)
                    {
                        var coveragesToRemove = new List<Coverage>();
                        var coveragesNotToAdd = new List<Coverage>();
                        //context.Entry(dbVehicle).CurrentValues.SetValues(newVehicle);
                        Mapper.Map<Vehicle, Vehicle>(newVehicle, dbVehicle);

                        foreach (var dbCoverage in dbVehicle.Coverages)
                            if (newVehicle.Coverages.Any(x => x.Id == dbCoverage.Id))
                            {
                                var newCoverage = newVehicle.Coverages.First(x => x.Id == dbCoverage.Id);
                                coveragesNotToAdd.Add(newCoverage);
                            }
                            else
                                coveragesToRemove.Add(dbCoverage);
                        foreach (var dbCoverage in newVehicle.Coverages.Where(newCoverage => coveragesNotToAdd.All(x => x.Id != newCoverage.Id)).Select(newCoverage => context.Coverages.Single(x => x.Id == newCoverage.Id)))
                        {
                            dbVehicle.Coverages.Add(dbCoverage);
                        }
                        foreach (var coverageToRemove in coveragesToRemove)
                            dbVehicle.Coverages.Remove(coverageToRemove);
                    }
                    else
                        this.vehicleDao.SaveVehicle(newVehicle);
                }
            }
        }
        private void UpdatePolicyEmployees(Policy newPolicy, Policy dbPolicy)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var employeesToRemove = dbPolicy.Employees.ToList().Where(dbEmployee => newPolicy.Employees.All(s => s.Id != dbEmployee.Id)).ToList();

                context.Employees.RemoveRange(employeesToRemove);

                foreach (var newEmployee in newPolicy.Employees)
                {
                    var dbEmployee = dbPolicy.Employees.SingleOrDefault(s => s.Id == newEmployee.Id);
                    if (dbEmployee != null)
                    {
                        var coveragesToRemove = new List<Coverage>();
                        var coveragesNotToAdd = new List<Coverage>();
                        //context.Entry(dbEmployee).CurrentValues.SetValues(newEmployee);
                        Mapper.Map<Employee, Employee>(newEmployee, dbEmployee);

                        foreach (var dbCoverage in dbEmployee.Coverages)
                            if (newEmployee.Coverages.Any(x => x.Id == dbCoverage.Id))
                            {
                                var newCoverage = newEmployee.Coverages.First(x => x.Id == dbCoverage.Id);
                                coveragesNotToAdd.Add(newCoverage);
                            }
                            else
                                coveragesToRemove.Add(dbCoverage);

                        foreach (var newCoverage in newEmployee.Coverages.Where(newCoverage => coveragesNotToAdd.All(x => x.Id != newCoverage.Id)))
                        {
                            var dbCoverage = context.Coverages.Single(x => x.Id == newCoverage.Id);
                            dbEmployee.Coverages.Add(dbCoverage);
                        }
                        foreach (var coverageToRemove in coveragesToRemove)
                            dbEmployee.Coverages.Remove(coverageToRemove);
                    }
                    else
                        this.employeeDao.SaveEmployee(newEmployee);
                }

            }
        }
        private void UpdatePolicyIntegral(Policy newPolicy, Policy dbPolicy)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var integralsToRemove = dbPolicy.Integrals.ToList().Where(dbIntegral => newPolicy.Integrals.All(s => s.Id != dbIntegral.Id)).ToList();

                context.Integrals.RemoveRange(integralsToRemove);

                foreach (var newIntegral in newPolicy.Integrals)
                {
                    var dbIntegral = dbPolicy.Integrals.SingleOrDefault(s => s.Id == newIntegral.Id);
                    if (dbIntegral != null)
                    {
                        var coveragesToRemove = new List<Coverage>();
                        var coveragesNotToAdd = new List<Coverage>();
                        //context.Entry(dbIntegral).CurrentValues.SetValues(newIntegral);
                        context.Entry(dbIntegral.Address).CurrentValues.SetValues(newIntegral.Address);
                        Mapper.Map<Integral, Integral>(newIntegral, dbIntegral);

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
                                var dbCoverage = context.Coverages.Single(x => x.Id == newCoverage.Id);
                                dbIntegral.Coverages.Add(dbCoverage);
                            }
                        foreach (var coverageToRemove in coveragesToRemove)
                            dbIntegral.Coverages.Remove(coverageToRemove);
                    }
                    else
                        this.integralDao.SaveIntegral(newIntegral);
                }
            }
        }
        private void UpdateFees(Policy policy)
        {
            using (var context = SegguDataModelContext.Create())
            {
                foreach (var fee in policy.Fees)
                {
                    fee.PolicyId = policy.Id;
                }

                var feesToDelete = context.Fees.Where(f => f.PolicyId == policy.Id);
                context.Fees.RemoveRange(feesToDelete);

                context.Fees.AddRange(policy.Fees);
            }
        }
        public IEnumerable<Policy> GetRosView(DateTime from, DateTime to)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Policies
                    .Include("Client")
                    .Include("Risk")
                    .Include("Risk.Company")
                    .Include("Client.Addresses")
                    .Include("Client.Addresses.Locality")
                    .Include("Client.Addresses.Locality.District")
                    .Include("Client.Addresses.Locality.District.Province")
                    .Where(ca => ca.EmissionDate > from && ca.EmissionDate < to && ca.EmissionDate != null);
            }
        }

        public override void Update(Policy obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Policies.Find(obj.Id);
                Mapper.Map<Policy, Policy>(obj, orig);
                context.SaveChanges();
            }
        }
    }
}
