using Seggu.Data;
using Seggu.Dtos;
using System;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class EmployeeDtoMapper
    {
        public static EmployeeDto GetDto(Employee obj)
        {
            var date = new DateTime(1753, 1, 1).ToShortDateString();

            var dto = new EmployeeDto();
            dto.Apellido = obj.LastName;
            dto.CUIT = obj.CUIT;
            dto.DNI = obj.DNI; 
            dto.EndorseId = obj.EndorseId.ToString();
            //dto.Fecha_Nacimiento = obj.BirthDate == null ? date : obj.BirthDate.Value.ToShortDateString();
            dto.Fecha_Nacimiento = obj.BirthDate;
            dto.Id = obj.Id.ToString();
            dto.Nombre = obj.FirstName;
            dto.PolicyId = obj.PolicyId.ToString();
            dto.IsRemoved = (bool)obj.IsRemoved;
            dto.Suma = obj.InsuranceAmount;
            dto.Coverages = obj.Coverages.OrderBy(x => x.Name).Select(c => CoverageDtoMapper.GetDto(c)).ToList();
            return dto;
        }
         
        public static Employee GetObject(EmployeeDto dto)
        {
            var obj = new Employee();

            obj.BirthDate = dto.Fecha_Nacimiento;
            obj.CUIT = dto.CUIT;
            obj.DNI = dto.DNI;
            obj.EndorseId = dto.EndorseId == null? (Guid?)null : new Guid(dto.EndorseId);
            obj.FirstName = dto.Nombre;
            obj.Id = new Guid(dto.Id);
            obj.LastName = dto.Apellido;
            obj.PolicyId = new Guid(dto.PolicyId);
            obj.IsRemoved = dto.IsRemoved;

            return obj;
        }

        public static Employee GetObjectWithCover(EmployeeDto dto)
        {
            var obj = new Employee();

            obj.BirthDate = dto.Fecha_Nacimiento;
            obj.CUIT = dto.CUIT ?? string.Empty;
            obj.DNI = dto.DNI ?? string.Empty;
            obj.EndorseId = string.IsNullOrEmpty(dto.EndorseId) ? (Guid?)null : new Guid(dto.EndorseId);
            obj.FirstName = dto.Nombre ?? string.Empty;
            obj.Id = string.IsNullOrEmpty(dto.Id) ? Guid.Empty : new Guid(dto.Id);
            obj.LastName = dto.Apellido ?? string.Empty;
            obj.PolicyId = string.IsNullOrEmpty(dto.PolicyId) ? Guid.Empty : new Guid(dto.PolicyId);
            obj.IsRemoved = dto.IsRemoved;
            obj.Coverages = dto.Coverages.Select(x => CoverageDtoMapper.GetObject(x)).ToList();
            obj.InsuranceAmount = dto.Suma;

            return obj;
        }
    }
}
