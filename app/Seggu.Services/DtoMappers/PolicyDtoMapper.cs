using Seggu.Domain;
using Seggu.Dtos;
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
            dto.EndorseCount = obj.Endorses.Count;
            dto.Bonus = (int)obj.Bonus;

            dto.Casualties = obj.Casualties.Select(c => CasualtyDtoMapper.GetDto(c)).ToList();
            dto.Compañía = obj.Risk.Company.Name;
            dto.ClientId = (int)obj.ClientId;
            dto.CompanyId = (int)obj.Risk.Company.Id;
            dto.CollectorId = (int?)obj.CollectorId ?? default(int);
            dto.Vence = obj.EndDate.ToShortDateString();
            dto.Endorses = (obj.Endorses ?? new List<Endorse>()).Select(e => EndorseDtoMapper.GetFullDto(e));
            dto.NetCharge = obj.NetCharge;

            dto.EmissionDate = obj.EmissionDate == null ? date : obj.EmissionDate.Value.ToShortDateString();

            dto.Id = (int)obj.Id;
            dto.IsAnnulled = obj.IsAnnulled;
            dto.IsRemoved = obj.IsRemoved;
            dto.IsRenovated = obj.IsRenovated;

            dto.Notes = obj.Notes;
            dto.Número = obj.Number;

            dto.Period = PeriodDtoMapper.ToString(obj.Period);
            dto.Premium = obj.Premium;
            dto.PreviousNumber = obj.PreviousNumber;
            dto.Prima = obj.Prima;
            dto.ProducerId = (int)obj.ProducerId;

            dto.RequestDate = obj.RequestDate.ToShortDateString();
            dto.ReceptionDate = obj.ReceptionDate == null ? date : obj.ReceptionDate.Value.ToShortDateString();
            dto.RiskId = (int)obj.RiskId;

            dto.Surcharge = obj.Surcharge;
            dto.PaymentDay = obj.PaymentDay;
            dto.PaymentBonus = obj.PaymentBonus;
            dto.StartDate = obj.StartDate.ToShortDateString();

            dto.TipoRiesgo = RiskTypeDtoMapper.ToString(obj.Risk.RiskType);

            dto.Value = obj.Value;
            if (obj.Vehicles != null)
                if (obj.Vehicles.Count() > 0)
                {
                    dto.Vehicles = obj.Vehicles.Where(v => v.EndorseId == null)
                        .Select(v => VehicleDtoMapper.GetDto(v)).ToList();
                    dto.Patente = obj.Vehicles.First().Plate;
                    dto.Objeto = obj.Vehicles.First().VehicleModel.Name; //¿para impresión?
                }
            if (obj.Employees != null)
                if (obj.Employees.Count() > 0)
                {
                    dto.Employees = obj.Employees.Where(v => v.EndorseId == null)
                        .Select(v => EmployeeDtoMapper.GetDto(v)).ToList();
                }
            if (obj.Integrals != null)
                if (obj.Integrals.Count() > 0)
                {
                    dto.Integrals = obj.Integrals.Where(v => v.EndorseId == null)
                        .Select(v => IntegralDtoMapper.GetDto(v)).ToList();
                }

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
            obj.PaymentDay = dto.PaymentDay;
            obj.PaymentBonus = dto.PaymentBonus;
            obj.Value = dto.Value;
            obj.NetCharge = dto.NetCharge;

            obj.Fees = dto.Fees?.Select(FeeDtoMapper.GetObject).ToList();
            obj.Vehicles = dto.Vehicles?.Select(VehicleDtoMapper.GetObjectWithCover).ToList();
            obj.Employees = dto.Employees?.Select(EmployeeDtoMapper.GetObjectWithCover).ToList();
            obj.Integrals = dto.Integrals?.Select(IntegralDtoMapper.GetObjectWithCover).ToList();
            obj.AttachedFiles = dto.AttachedFiles.Select(x => AttachedFileDtoMapper.GetObject(new AttachedFileDto { FilePath = x.FilePath, PolicyId = x.PolicyId })).ToList();
            return obj;
        }
        public static PolicyRosViewDto GetRosView(Policy obj)
        {
            var dto = new PolicyRosViewDto();
            dto.EmissionDate = obj.EmissionDate.HasValue ? obj.EmissionDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            dto.ClientDocument = obj.Client.Document;
            dto.ClientFullName = obj.Client.FirstName + " " + obj.Client.LastName;
            var address = obj.Client.Addresses.First();
            dto.ClientAddressPostalCode = address.PostalCode;
            dto.ClientAddressLine = address.Street + " " + address.Number + ", " + address.Locality.Name + ", " + address.Locality.District.Name + ", " + address.Locality.District.Province.Name;
            dto.RiskType = obj.Risk.RiskType == RiskType.Automotores ? "Automovil" : (obj.Risk.RiskType == RiskType.Combinados_Integrales ? "Integral De Comercio" : "Seguro de Vida");
            dto.Value = obj.Value;
            dto.StartDate = obj.StartDate.ToString("yyyy-MM-dd");
            dto.EndDate = obj.EndDate.ToString("yyyy-MM-dd");
            return dto;
        }
    }
}