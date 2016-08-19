using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class EmployeeDao : IdParseEntityDao<Employee>, IEmployeeDao
    {
        public EmployeeDao()
            : base()
        {

        }

        public IEnumerable<Employee> GetByPolicyId(long policyId)
        {
            return this.Set.Where(x => x.PolicyId == policyId);
        }

        public void SaveEmployee(Employee employee)
        {
            var coverages = new List<Coverage>(employee.Coverages).ToList();
            var dbEmployee = context.Employees
                                    .Include("Coverages")
                                    .FirstOrDefault(c => c.Id == employee.Id) ?? employee;

            dbEmployee.Coverages.Clear();
            context.Entry(dbEmployee).State = EntityState.Added;

            employee.Id = dbEmployee.Id;
            Mapper.Map<Employee, Employee>(employee, dbEmployee);

            //context.Entry(dbEmployee).CurrentValues.SetValues(employee);

            foreach (var dbCover in context.Coverages)
            {
                if (coverages.Any(cov => cov.Id == dbCover.Id))
                {
                    context.Coverages.Attach(dbCover);
                    dbEmployee.Coverages.Add(dbCover);
                }
                //else
                //dbVehicle.Coverages.Remove(dbCover);
            }
            context.SaveChanges();
        }

        public override void Update(Employee obj)
        {
            //var orig = context.Employees.Find(obj.Id);
            //Mapper.Map<Employee, Employee>(obj, orig);
            //context.SaveChanges();
        }
    }
}
