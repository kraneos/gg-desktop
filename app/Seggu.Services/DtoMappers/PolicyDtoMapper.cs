using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class PolicyDtoMapper
    {
        public static PolicyFullDto GetFullDto(Policy obj)
        {
            var date = new DateTime(1753, 1, 1).ToShortDateString();
            var dto = new PolicyFullDto();
            dto.AnnulationDate = obj.AnnulationDate == null ? date : obj.AnnulationDate.Value.ToShortDateString();
            dto.Asegurado = obj.Client.FirstName + " " + obj.Client.LastName;
            
            dto.Bonus = (int)obj.Bonus;

            dto.Casualties = obj.Casualties.Select(c => CasualtyDtoMapper.GetDto(c)).ToList();
            dto.Compañía = obj.Risk.Company.Name;
            dto.ClientId = obj.ClientId;
            dto.CompanyId = obj.Risk.Company.Id;
            dto.CollectorId = obj.CollectorId ?? default(int);
            dto.Vence = obj.EndDate.ToShortDateString();
            dto.Endorses = (obj.Endorses ?? new List<Endorse>()).Select(e => EndorseDtoMapper.GetFullDto(e));

            dto.EmissionDate = obj.EmissionDate == null ? date : obj.EmissionDate.Value.ToShortDateString();
            
            dto.Id = obj.Id;
            dto.IsAnnulled = obj.IsAnnulled;
            dto.IsRemoved = obj.IsRemoved;
            dto.IsRenovated = obj.IsRenovated;
            
            dto.Notes = obj.Notes;
            dto.Número = obj.Number;
            
            dto.Period = PeriodDtoMapper.ToString(obj.Period);
            dto.Premium = obj.Premium;
            dto.PreviousNumber = obj.PreviousNumber;
            dto.Prima = obj.Prima;
            dto.ProducerId = obj.ProducerId;
            
            dto.RequestDate = obj.RequestDate.ToShortDateString();
            dto.ReceptionDate = obj.ReceptionDate == null ? date : obj.ReceptionDate.Value.ToShortDateString();
            dto.RiskId = obj.RiskId;
            
            dto.Surcharge = obj.Surcharge;
            dto.StartDate = obj.StartDate.ToShortDateString();
            
            dto.TipoRiesgo = RiskTypeDtoMapper.ToString(obj.Risk.RiskType);
            
            dto.Value = obj.Value;
            if(obj.Vehicles !=null)
                if (obj.Vehicles.Count() > 0)
                {
                    dto.Vehicles = obj.Vehicles.Where(v=> v.EndorseId == null)
                        .Select(v => VehicleDtoMapper.GetDto(v)).ToList();
                    dto.Patente = obj.Vehicles.First().Plate;
                    dto.Objeto = obj.Vehicles.First().VehicleModel.Name; //¿para impresión?
                }
            dto.Employees = (obj.Employees ?? new List<Employee>()).Select(e => EmployeeDtoMapper.GetDto(e));
            dto.Integrals = (obj.Integrals ?? new List<Integral>()).Select(i => IntegralDtoMapper.GetDto(i));

            return dto;
        }
        public static Policy GetObjectWithCover(PolicyFullDto dto)
        {
            var obj = new Policy();
            obj.AnnulationDate = dto.AnnulationDate == null ? (DateTime?)null : DateTime.Parse(dto.AnnulationDate);
            obj.Bonus = dto.Bonus;

            obj.ClientId = dto.ClientId;
            obj.CollectorId = dto.CollectorId;
            obj.EndDate = DateTime.Parse(dto.Vence);

            obj.EmissionDate = dto.EmissionDate == null ? (DateTime?)null : DateTime.Parse(dto.EmissionDate);
            obj.Id = dto.Id;
            obj.IsAnnulled = dto.IsAnnulled;
            obj.IsRemoved = dto.IsRemoved;
            obj.IsRenovated = dto.IsRemoved;
            obj.Notes = dto.Notes;
            obj.Number = dto.Número;
            obj.Period = PeriodDtoMapper.ToEnum(dto.Period);
            obj.Premium = dto.Premium;
            obj.PreviousNumber = dto.PreviousNumber;
            obj.Prima = dto.Prima;
            obj.ProducerId = dto.ProducerId;
            obj.ReceptionDate = dto.ReceptionDate == null ? (DateTime?)null : DateTime.Parse(dto.ReceptionDate);
            obj.RequestDate = DateTime.Parse(dto.RequestDate);
            obj.RiskId = dto.RiskId;
            obj.StartDate = DateTime.Parse(dto.StartDate);
            obj.Surcharge = dto.Surcharge;
            obj.Value = dto.Value;

            obj.Fees = dto.Fees == null ? null : dto.Fees.Select(f => FeeDtoMapper.GetObject(f)).ToList();
            obj.Vehicles = dto.Vehicles == null ? null : dto.Vehicles.Select(v => VehicleDtoMapper.GetObjectWithCover(v)).ToList();
            obj.Employees = dto.Employees == null ? null : dto.Employees.Select(e => EmployeeDtoMapper.GetObjectWithCover(e)).ToList();
            obj.Integrals = dto.Integrals == null ? null : dto.Integrals.Select(i => IntegralDtoMapper.GetObjectWithCover(i)).ToList();
            //obj.AttachedFiles = dto.AttFiles == null ? null : dto.AttFiles.Select(at => AttachedFileDtoMapper.GetObject(at)).ToList();
            return obj;
        }
    }
}