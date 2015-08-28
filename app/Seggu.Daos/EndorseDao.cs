using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;

namespace Seggu.Daos
{
    public sealed class EndorseDao : GenericDao<Endorse>, IEndorseDao
    {
        private IVehicleDao vehicleDao;
        private IEmployeeDao employeeDao;

        public EndorseDao(IVehicleDao vehicleDao, IEmployeeDao employeeDao)
        {
            this.vehicleDao = vehicleDao;
            this.employeeDao = employeeDao;
        }
        public IEnumerable<Endorse> GetByPolicyId(int Id)
        {
            return
                from e in this.Set
                where e.PolicyId == Id
                select e;
        }

        public void SaveEndorse(Endorse obj)
        {
            //obj.Id = Guid.NewGuid();
            using (var scope = new TransactionScope())
            {
                if (obj.Vehicles != null)
                    foreach (var vehicle in obj.Vehicles) { }
                        //vehicle.Id = Guid.NewGuid();
                if (obj.Fees != null)
                    foreach (var fee in obj.Fees) { }
                        //fee.Id = Guid.NewGuid();
                if (obj.Employees != null)
                    foreach (var employee in obj.Employees) { }
                        //employee.Id = Guid.NewGuid();

                var entry = this.container.Entry(obj);
                entry.State = EntityState.Added;
                this.container.SaveChanges();
                scope.Complete();
            }
        }

        public void UpdateEndorse(Endorse obj)
        {
            using (var scope = new TransactionScope())
            {
                var endorse = this.Set.Find(obj.Id);
                var endorseEntry = this.container.Entry<Endorse>(endorse);
                endorseEntry.CurrentValues.SetValues(obj);

                if (obj.Vehicles != null)
                {
                    if (obj.Vehicles.Count > 0)
                    {
                        var firstVehicle = obj.Vehicles.ElementAt(0);
                        var vehicle = this.container.Vehicles.Find(firstVehicle.Id);
                        var vehicleEntry = this.container.Entry<Vehicle>(vehicle);
                        vehicleEntry.CurrentValues.SetValues(firstVehicle);
                    }
                }
                if (obj.Fees.Count > 0)
                    this.UpdateFees(obj);
                this.container.SaveChanges();
                scope.Complete();
            }
        }

        public void Edit(Endorse newEndorse)
        {
            Endorse dbEndorse = new Endorse();
            if (newEndorse.Vehicles != null)
            {
                dbEndorse = container.Endorses
                                    .Include("Vehicles.Coverages")
                                    .Include(x => x.Fees)
                                    .Single(c => c.Id == newEndorse.Id);
                UpdateEndorseVehicles(newEndorse, dbEndorse);
            }
            else if (newEndorse.Employees != null)
            {
                dbEndorse = container.Endorses
                                    .Include("Employees.Coverages")
                                    .Include(x => x.Fees)
                                    .Single(c => c.Id == newEndorse.Id);
                UpdateEndorseEmployees(newEndorse, dbEndorse);
            }
            UpdateFees(newEndorse);
            container.Entry(dbEndorse).CurrentValues.SetValues(newEndorse);
            container.SaveChanges();
        }
            private void UpdateEndorseVehicles(Endorse newEndorse, Endorse dbEndorse)
            {
                var vehiclesToRemove = new List<Vehicle>();
                foreach (var dbVehicle in dbEndorse.Vehicles.ToList())
                    if (!newEndorse.Vehicles.Any(s => s.Id == dbVehicle.Id))
                        vehiclesToRemove.Add(dbVehicle);

                container.Vehicles.RemoveRange(vehiclesToRemove);
                foreach (var newVehicle in newEndorse.Vehicles)
                {
                    var dbVehicle = dbEndorse.Vehicles.SingleOrDefault(s => s.Id == newVehicle.Id);
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
            private void UpdateEndorseEmployees(Endorse newEndorse, Endorse dbEndorse)
            {
                var employeesToRemove = new List<Employee>();
                foreach (var dbEmployee in dbEndorse.Employees.ToList())
                    if (!newEndorse.Employees.Any(s => s.Id == dbEmployee.Id))
                        employeesToRemove.Add(dbEmployee);

                container.Employees.RemoveRange(employeesToRemove);

                foreach (var newEmployee in newEndorse.Employees)
                {
                    var dbEmployee = dbEndorse.Employees.SingleOrDefault(s => s.Id == newEmployee.Id);
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
            private void UpdateFees(Endorse endorse)
            {
                foreach (var fee in endorse.Fees)
                {
                    //if (fee.Id == Guid.Empty)
                    //    fee.Id = Guid.NewGuid();
                    fee.EndorseId = endorse.Id;
                }

                var feesToDelete = this.container.Fees.Where(f => f.EndorseId == endorse.Id);
                this.container.Fees.RemoveRange(feesToDelete);
                this.container.Fees.AddRange(endorse.Fees);
            }
    }
}
