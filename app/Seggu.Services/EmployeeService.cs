using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class EmployeeService : IEmployeeService
    {
        private IEmployeeDao employeeDao;
        public EmployeeService(IEmployeeDao employeeDao)
        {
            this.employeeDao = employeeDao;
        }

        public IEnumerable<EmployeeDto> GetByPolicyId(string policyId)
        {
            var employees = employeeDao.GetByPolicyId(new Guid(policyId));
            return employees.Select(x => EmployeeDtoMapper.GetDto(x));
        }

        public void Save(EmployeeDto dto)
        {
            bool isNew = dto.Id == null;
            var obj = EmployeeDtoMapper.GetObject(dto);
            if (isNew)
                employeeDao.Save(obj);
            else
                employeeDao.Update(obj);
        }
    }
}
