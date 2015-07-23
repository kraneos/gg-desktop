using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetByPolicyId(string policyId);
        void Save(EmployeeDto dto);

    }
}
