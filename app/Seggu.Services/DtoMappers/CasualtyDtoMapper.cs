using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class CasualtyDtoMapper
    {
        public static CasualtyDto GetDto(Casualty obj)
        {
            var date = new DateTime(1753, 1, 1).ToShortDateString();
            var dto = new CasualtyDto();
            dto.CasualtyTypeId = (int)obj.CasualtyTypeId;
            dto.DefinedCompensation = obj.DefinedCompensation;
            dto.EstimatedCompensation = obj.EstimatedCompensation;
            dto.Id = (int)obj.Id;
            dto.Notes = obj.Notes;
            dto.Number = obj.Number.ToString();
            dto.OccurredDate = obj.OccurredDate.ToShortDateString();
            dto.OurCharge = obj.OurCharge;
            dto.PoliceReportDate = obj.PoliceReportDate == null ? date : obj.PoliceReportDate.Value.ToShortDateString();
            dto.PolicyId = (int)obj.PolicyId;
            dto.ReceiveDate = obj.ReceiveDate.ToShortDateString();
            dto.Producer = obj.Policy.Producer.Name;
            //dto.Client = ClientDtoMapper.GetDto(obj.Policy.Client);
            //dto.Vehicles = obj.Policy.Vehicles.Select(x => VehicleDtoMapper.GetDto(x)).ToList();

            return dto;
        }

        public static Casualty GetObject(CasualtyDto dto)
        {
            Casualty obj = new Casualty();
            obj.CasualtyTypeId = dto.CasualtyTypeId;
            obj.DefinedCompensation = dto.DefinedCompensation;
            obj.EstimatedCompensation = dto.EstimatedCompensation;
            obj.Id = dto.Id;
            obj.Notes = dto.Notes;
            obj.Number = short.Parse(dto.Number);
            obj.OccurredDate = DateTime.Parse(dto.OccurredDate);
            obj.OurCharge = dto.OurCharge;
            obj.PoliceReportDate = DateTime.Parse(dto.PoliceReportDate);
            obj.PolicyId = dto.PolicyId;
            obj.ReceiveDate = DateTime.Parse(dto.ReceiveDate);
            
            return obj;
        }
    }
}
