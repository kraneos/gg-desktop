using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public class EndorseDtoMapper
    {
        public static EndorseDto GetDto(Endorse obj)
        {
            var date = new DateTime(1753, 1, 1).ToShortDateString();
            var dto = new EndorseDto();
            dto.Asegurado = obj.Client.FirstName + " " + obj.Client.LastName;
            dto.AnnulationDate = obj.AnnulationDate == null ? date : obj.AnnulationDate.Value.ToShortDateString();

            dto.ClientId = (int?)obj.ClientId ?? default(int);
            dto.CompanyId = (int)obj.Policy.Risk.Company.Id;
            dto.Motivo = obj.Cause;

            dto.EndDate = obj.EndDate.ToShortDateString();
            dto.EmissionDate = obj.EmissionDate == null ? date : obj.EmissionDate.Value.ToShortDateString();
            dto.EndorseType = EndorseTypeDtoMapper.ToString(obj.EndorseType);

            dto.Id = (int)obj.Id;
            dto.IsAnnulled = obj.IsAnnulled == null ? false : true;
            dto.IsRemoved = obj.IsRemoved == null ? false : true;

            dto.Notes = obj.Notes;
            dto.Número = obj.Number;

            dto.PolicyId = (int)obj.PolicyId;
            dto.PolicyNumber = obj.Policy.Number;
            dto.Premium = obj.Premium;
            dto.Prima = obj.Prima;
            dto.ProducerId = (int)obj.Policy.ProducerId;

            dto.RequestDate = obj.RequestDate.ToShortDateString();
            dto.ReceptionDate = obj.ReceptionDate == null ? date : obj.ReceptionDate.Value.ToShortDateString();
            dto.RiskId = (int)obj.Policy.Risk.Id;

            dto.StartDate = obj.StartDate.ToShortDateString();
            dto.Surcharge = obj.Surcharge;

            dto.TipoRiesgo = RiskTypeDtoMapper.ToString(obj.Policy.Risk.RiskType);

            dto.Value = obj.Value;
            dto.Vehicles = obj.Vehicles.Select(v => VehicleDtoMapper.GetDto(v)).ToList();
            return dto;
        }
        public static EndorseFullDto GetFullDto(Endorse obj)
        {
            var date = new DateTime(1753, 1, 1).ToShortDateString();
            var dto = new EndorseFullDto();
            dto.Asegurado = obj.Client.FirstName + " " + obj.Client.LastName;
            dto.AnnulationDate = obj.AnnulationDate == null ? date : obj.AnnulationDate.Value.ToShortDateString();

            dto.ClientId = (int?)obj.ClientId ?? default(int);
            dto.CompanyId = (int)obj.Policy.Risk.Company.Id;
            dto.Motivo = obj.Cause;

            dto.EndDate = obj.EndDate.ToShortDateString();
            dto.EmissionDate = obj.EmissionDate == null ? date : obj.EmissionDate.Value.ToShortDateString();
            dto.EndorseType = EndorseTypeDtoMapper.ToString(obj.EndorseType);

            dto.Id = (int)obj.Id;
            dto.IsAnnulled = obj.IsAnnulled == null ? false : true;
            dto.IsRemoved = obj.IsRemoved == null ? false : true;

            dto.Notes = obj.Notes;
            dto.Número = obj.Number;

            dto.PolicyId = (int)obj.PolicyId;
            dto.PolicyNumber = obj.Policy.Number;
            dto.Premium = obj.Premium;
            dto.Prima = obj.Prima;
            dto.ProducerId = (int)obj.Policy.ProducerId;

            dto.RequestDate = obj.RequestDate.ToShortDateString();
            dto.ReceptionDate = obj.ReceptionDate == null ? date : obj.ReceptionDate.Value.ToShortDateString();
            dto.RiskId = (int)obj.Policy.Risk.Id;

            dto.StartDate = obj.StartDate.ToShortDateString();
            dto.Surcharge = obj.Surcharge;

            dto.TipoRiesgo = RiskTypeDtoMapper.ToString(obj.Policy.Risk.RiskType);

            dto.Value = obj.Value;
            dto.Vehicles = (obj.Vehicles ?? new List<Vehicle>()).Select(v => VehicleDtoMapper.GetDto(v));
            dto.Employees = (obj.Employees ?? new List<Employee>()).Select(e => EmployeeDtoMapper.GetDto(e));
            dto.Integrals = (obj.Integrals ?? new List<Integral>()).Select(i => IntegralDtoMapper.GetDto(i));

            return dto;
        }

        public static Endorse GetObjectWithCover(EndorseFullDto dto)
        {
            var obj = new Endorse();
            obj.AnnulationDate = dto.AnnulationDate == null ? (DateTime?)null : DateTime.Parse(dto.AnnulationDate);
            obj.ClientId = dto.ClientId;
            obj.Cause = dto.Motivo;
            obj.EndDate = DateTime.Parse(dto.EndDate);
            obj.EndorseType = EndorseTypeDtoMapper.ToEnum(dto.EndorseType);
            obj.EmissionDate = DateTime.Parse(dto.EmissionDate);
            obj.Id = dto.Id;
            obj.IsAnnulled = dto.IsAnnulled;
            obj.IsRemoved = dto.IsRemoved;
            obj.Notes = dto.Notes;
            obj.Number = dto.Número;
            obj.Premium = dto.Premium;
            obj.Prima = dto.Prima;
            obj.PolicyId = dto.PolicyId;
            obj.ReceptionDate = DateTime.Parse(dto.ReceptionDate);
            obj.RequestDate = DateTime.Parse(dto.RequestDate);
            obj.StartDate = DateTime.Parse(dto.StartDate);
            obj.Surcharge = dto.Surcharge;
            obj.Value = dto.Value;

            obj.Fees = dto.Fees == null ? null : dto.Fees.Select(f => FeeDtoMapper.GetObject(f)).ToList();
            obj.Vehicles = dto.Vehicles == null ? null : dto.Vehicles.Select(v => VehicleDtoMapper.GetObjectWithCover(v)).ToList();
            obj.Employees = dto.Employees == null ? null : dto.Employees.Select(e => EmployeeDtoMapper.GetObjectWithCover(e)).ToList();
            obj.Integrals = dto.Integrals== null ? null : dto.Integrals.Select(i => IntegralDtoMapper.GetObjectWithCover(i)).ToList();
            return obj;
        }
    }
}
