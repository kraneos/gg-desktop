using Seggu.Domain;
using Seggu.Dtos;
using System;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class LiquidationDtoMapper
    {
        public static LiquidationDto GetDto(Liquidation l)
        {
            var date = DateTime.MinValue.AddYears(1755).ToShortDateString();
            var dto = new LiquidationDto();
            dto.Id = (int)l.Id;
            dto.Compañía = l.Company.Name;
            dto.CompanyId = (int)l.CompanyId;
            dto.Fecha = l.Date.ToShortDateString();
            dto.Registered = l.Registered ;
            dto.Recepción = l.ReceptionDate == null ? date : l.ReceptionDate.Value.ToShortDateString();
            dto.Total = l.Total;
            dto.Notas = l.Notes;
            return dto;
        }

        public static Liquidation GetObject(LiquidationDto dto)
        {
            var date = DateTime.MinValue.AddYears(1755);
            var obj = new Liquidation();
            obj.Id = dto.Id;
            obj.CompanyId = dto.CompanyId;
            obj.Date = DateTime.Parse(dto.Fecha);
            obj.Registered = dto.Registered;
            obj.ReceptionDate = dto.Recepción == null ? date : DateTime.Parse(dto.Recepción);
            obj.Notes = dto.Notas;
            obj.Total = int.Parse(dto.Total.ToString());
            return obj;
        }
    }
}
