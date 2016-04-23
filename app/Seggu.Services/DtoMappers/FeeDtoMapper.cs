using Seggu.Domain;
using Seggu.Dtos;
using System;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class FeeDtoMapper
    {
        public static FeeDto GetDto(Fee x)
        {
            var date = DateTime.MinValue.AddYears(1755).ToShortDateString();

            var dto = new FeeDto();
            dto.Cliente = x.Policy.Client.LastName + ", " + x.Policy.Client.FirstName;
            dto.Nro_Póliza = x.Policy.Number;
            dto.Nro_Endoso = x.Endorse == null ? string.Empty : x.Endorse.Number;
            dto.CompanyId = (int)x.Policy.Risk.CompanyId;
            dto.Annulated =  x.Annulated;
            dto.Saldo = x.Balance;
            //lista de cobranzas
            //dto.Cobrada = x.CollectionDate == null ? date : x.CollectionDate.Value.ToShortDateString();
            dto.Pago_Cía= x.CompanyPayment;
            dto.Venc_Cuota = x.ExpirationDate.ToShortDateString();
            dto.Fecha_Liquidación = x.RegisteredLiqDate;
            dto.FeeSelectionId = (int?)x.FeeSelectionId ?? default(int);
            dto.Id = (int)x.Id;
            dto.Cuota = x.Number.ToString();
            dto.PolicyId = (int)x.PolicyId;
            dto.Valor = x.Value;
            dto.Estado = FeeStateDtoMapper.ToString(x.State);
            dto.EndorseId = (int?)x.EndorseId ?? default(int);
            return dto;
        }

        public static Fee GetObject(FeeDto dto)
        {
            var date = DateTime.MinValue.AddYears(1755);
            var fs = new Fee();
            fs.Id = dto.Id;
            fs.Annulated = dto.Annulated;
            fs.Balance = dto.Saldo;
            //fs.CollectionDate = dto.Cobrada == null? date : DateTime.Parse(dto.Cobrada);
            fs.CompanyPayment = dto.Pago_Cía;
            fs.EndorseId = dto.EndorseId;
            fs.ExpirationDate = DateTime.Parse(dto.Venc_Cuota);
            fs.RegisteredLiqDate = dto.Fecha_Liquidación;
            fs.FeeSelectionId = dto.FeeSelectionId;
            fs.Number = short.Parse(dto.Cuota);
            fs.PolicyId = dto.PolicyId;
            fs.State = FeeStateDtoMapper.ToEnum(dto.Estado);
            fs.Value = dto.Valor;
            return fs;
        }
    }
}
