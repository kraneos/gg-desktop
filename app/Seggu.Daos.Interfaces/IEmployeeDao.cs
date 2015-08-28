using Seggu.Domain;
using System;
using System.Collections.Generic;


namespace Seggu.Daos.Interfaces
{
    public interface IEmployeeDao : IGenericDao<Employee>
    {
        IEnumerable<Employee> GetByPolicyId(int policyId);

        void SaveEmployee(Employee newVehicle);
    }
}
