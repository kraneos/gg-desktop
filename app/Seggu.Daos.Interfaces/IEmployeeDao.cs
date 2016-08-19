using Seggu.Domain;
using System;
using System.Collections.Generic;


namespace Seggu.Daos.Interfaces
{
    public interface IEmployeeDao : IParseIdEntityDao<Employee>
    {
        List<Employee> GetByPolicyId(long policyId);

        void SaveEmployee(Employee newVehicle);
    }
}
