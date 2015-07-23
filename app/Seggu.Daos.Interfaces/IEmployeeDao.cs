using Seggu.Data;
using System;
using System.Collections.Generic;


namespace Seggu.Daos.Interfaces
{
    public interface IEmployeeDao : IGenericDao<Employee>
    {
        IEnumerable<Employee> GetByPolicyId(Guid policyId);

        void SaveEmployee(Employee newVehicle);
    }
}
