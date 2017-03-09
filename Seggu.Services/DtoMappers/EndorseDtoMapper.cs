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
        public static EndorseFullDto GetFullDto(Endorse obj)
        {
            var date = new DateTime(1753, 1, 1).ToShortDateString();
            var dto = new EndorseFullDto
            {
                Asegurado = obj.Client.FirstName + " " + obj.Client.LastName,
                AnnulationDate = obj.AnnulationDate?.ToShortDateString() ?? date,
                ClientId = (int?) obj.ClientId ?? default(int),
                CompanyId = (int) obj.Policy.Risk.Company.Id,
                Motivo = obj.Cause,
                EndDate = obj.EndDate.ToShortDateString(),
                EmissionDate = obj.EmissionDate?.ToShortDateString() ?? date,
                EndorseType = EndorseTypeDtoMapper.ToString(obj.EndorseType),
                Id = (int) obj.Id,
                IsAnnulled = obj.IsAnnulled != null,
                IsRemoved = obj.IsRemoved != null,
                Notes = obj.Notes,
                Número = obj.Number,
                NetCharge = obj.NetCharge,
                PolicyId = (int) obj.PolicyId,
                PolicyNumber = obj.Policy.Number,
                Premium = obj.Premium,
                Prima = obj.Prima,
                ProducerId = (int) obj.Policy.ProducerId,
                PaymentBonus = obj.PaymentBonus,
                RequestDate = obj.RequestDate.ToShortDateString(),
                ReceptionDate = obj.ReceptionDate?.ToShortDateString() ?? date,
                RiskId = (int) obj.Policy.Risk.Id,
                StartDate = obj.StartDate.ToShortDateString(),
                Surcharge = obj.Surcharge,
                TipoRiesgo = RiskTypeDtoMapper.ToString(obj.Policy.Risk.RiskType),
                Value = obj.Value,
                Vehicles = (obj.Vehicles ?? new List<Vehicle>()).Select(VehicleDtoMapper.GetDto),
                Employees = (obj.Employees ?? new List<Employee>()).Select(EmployeeDtoMapper.GetDto),
                Integrals = (obj.Integrals ?? new List<Integral>()).Select(IntegralDtoMapper.GetDto)
            };

            return dto;
        }

        public static Endorse GetObjectWithCover(EndorseFullDto dto)
        {
            var obj = new Endorse
            {
                AnnulationDate = dto.AnnulationDate == null ? (DateTime?) null : DateTime.Parse(dto.AnnulationDate),
                ClientId = dto.ClientId,
                Cause = dto.Motivo,
                EndDate = DateTime.Parse(dto.EndDate),
                EndorseType = EndorseTypeDtoMapper.ToEnum(dto.EndorseType),
                EmissionDate = DateTime.Parse(dto.EmissionDate),
                Id = dto.Id,
                IsAnnulled = dto.IsAnnulled,
                IsRemoved = dto.IsRemoved,
                NetCharge = dto.NetCharge,
                Notes = dto.Notes,
                Number = dto.Número,
                Premium = dto.Premium,
                Prima = dto.Prima,
                PaymentBonus = dto.PaymentBonus,
                PolicyId = dto.PolicyId,
                ReceptionDate = DateTime.Parse(dto.ReceptionDate),
                RequestDate = DateTime.Parse(dto.RequestDate),
                StartDate = DateTime.Parse(dto.StartDate),
                Surcharge = dto.Surcharge,
                Value = dto.Value,
                Fees = dto.Fees?.Select(FeeDtoMapper.GetObject).ToList(),
                Vehicles =
                    dto.Vehicles?.Select(VehicleDtoMapper.GetObjectWithCover).ToList(),
                Employees =
                    dto.Employees?.Select(EmployeeDtoMapper.GetObjectWithCover).ToList(),
                Integrals =
                    dto.Integrals?.Select(IntegralDtoMapper.GetObjectWithCover).ToList()
            };

            return obj;
        }
    }
}
