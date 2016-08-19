using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class EndorseDao : IdParseEntityDao<Endorse>, IEndorseDao
    {
        private readonly IVehicleDao vehicleDao;
        private readonly IEmployeeDao employeeDao;

        public EndorseDao(SegguDataModelContext context, IVehicleDao vehicleDao, IEmployeeDao employeeDao)
            : base()
        {
            this.vehicleDao = vehicleDao;
            this.employeeDao = employeeDao;
        }
        public IEnumerable<Endorse> GetByPolicyId(long Id)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return
                    from e in context.Endorses
                    where e.PolicyId == Id
                    select e;
            }
        }
        public void SaveEndorse(Endorse obj)
        {
            //obj.Id = Guid.NewGuid();
            //using (var scope = new TransactionScope())
            //{
            using (var context = SegguDataModelContext.Create())
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

                var entry = context.Entry(obj);
                entry.State = EntityState.Added;
                context.SaveChanges();
            }
            //    scope.Complete();
            //}
        }
        public void UpdateEndorse(Endorse obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var endorse = context.Endorses.Find(obj.Id);
                Mapper.Map<Endorse, Endorse>(obj, endorse);

                if (obj.Vehicles?.Count > 0)
                {
                    var firstVehicle = obj.Vehicles.ElementAt(0);
                    var vehicle = context.Vehicles.Find(firstVehicle.Id);
                    Mapper.Map<Vehicle, Vehicle>(vehicle, firstVehicle);
                }
                if (obj.Fees.Count > 0)
                    UpdateFees(obj);
                context.SaveChanges();
            }
        }
        public void Edit(Endorse newEndorse)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var dbEndorse = new Endorse();
                if (newEndorse.Vehicles != null)
                {
                    dbEndorse = context.Endorses
                                        .Include("Vehicles.Coverages")
                                        .Include(x => x.Fees)
                                        .Single(c => c.Id == newEndorse.Id);
                    UpdateEndorseVehicles(newEndorse, dbEndorse);
                }
                else if (newEndorse.Employees != null)
                {
                    dbEndorse = context.Endorses
                                        .Include("Employees.Coverages")
                                        .Include(x => x.Fees)
                                        .Single(c => c.Id == newEndorse.Id);
                    UpdateEndorseEmployees(newEndorse, dbEndorse);
                }
                UpdateFees(newEndorse);
                //context.Entry(dbEndorse).CurrentValues.SetValues(newEndorse);
                Mapper.Map<Endorse, Endorse>(newEndorse, dbEndorse);
                context.SaveChanges();
            }
        }
        private void UpdateEndorseVehicles(Endorse newEndorse, Endorse dbEndorse)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var vehiclesToRemove = dbEndorse.Vehicles.ToList().Where(dbVehicle => newEndorse.Vehicles.All(s => s.Id != dbVehicle.Id)).ToList();

                context.Vehicles.RemoveRange(vehiclesToRemove);
                foreach (var newVehicle in newEndorse.Vehicles)
                {
                    var dbVehicle = dbEndorse.Vehicles.SingleOrDefault(s => s.Id == newVehicle.Id);
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
                        foreach (var newCoverage in newVehicle.Coverages.Where(newCoverage => coveragesNotToAdd.All(x => x.Id != newCoverage.Id)))
                        {
                            var dbCoverage = context.Coverages.Single(x => x.Id == newCoverage.Id);
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
        private void UpdateEndorseEmployees(Endorse newEndorse, Endorse dbEndorse)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var employeesToRemove = dbEndorse.Employees.ToList().Where(dbEmployee => newEndorse.Employees.All(s => s.Id != dbEmployee.Id)).ToList();

                context.Employees.RemoveRange(employeesToRemove);

                foreach (var newEmployee in newEndorse.Employees)
                {
                    var dbEmployee = dbEndorse.Employees.SingleOrDefault(s => s.Id == newEmployee.Id);
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

                        foreach (var dbCoverage in newEmployee.Coverages.Where(newCoverage => coveragesNotToAdd.All(x => x.Id != newCoverage.Id)).Select(newCoverage => context.Coverages.Single(x => x.Id == newCoverage.Id)))
                        {
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
        private static void UpdateFees(Endorse endorse)
        {
            using (var context = SegguDataModelContext.Create())
            {
                foreach (var fee in endorse.Fees)
                {
                    fee.EndorseId = endorse.Id;
                }

                var feesToDelete = context.Fees.Where(f => f.EndorseId == endorse.Id);
                context.Fees.RemoveRange(feesToDelete);
                context.Fees.AddRange(endorse.Fees);
            }
        }

        public override void Update(Endorse obj)
        {
            //var orig = context.Endorses.Find(obj.Id);
            //Mapper.Map<Endorse, Endorse>(obj, orig);
            //context.SaveChanges();
        }
    }
}
