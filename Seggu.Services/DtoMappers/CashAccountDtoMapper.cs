using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Services.Dtos;
using System;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class CashAccountDtoMapper
    {
        public static CashAccountDto GetDto(CashAccount x)
        {
            var dto = new CashAccountDto();
            dto.Id = (int)x.Id;
            dto.Amount = x.Amount;
            dto.Date = x.Date;
            dto.Description = x.Description;
            dto.Balance = x.Balance;
            dto.LedgerAccountName = x.LedgerAccount.Name;
            dto.ReceiptNumber = x.ReceiptNumber;
            //dto.ProducerId = x.Producer.Name;
            dto.AssetName = x.Asset.Name;
            return dto;
        }

        public static CashAccountDto GetCashAccountDto(CashAccount x)
        {
            var dto = new CashAccountDto();
            dto.Id = (int)x.Id;
            return dto;
        }

        public static CashAccount GetObject(CashAccountDto x)
        {
            var c = new CashAccount();
            c.Id = x.Id; 
            c.Amount = x.Amount;
            c.AssetId = x.AssetId;
            c.Balance = x.Balance;
            c.Date = x.Date;
            c.Description = x.Description;
            c.ReceiptNumber = x.ReceiptNumber;
            c.LedgerAccountId = x.LedgerAccountId;
            c.ProducerId = x.ProducerId;
            c.FeeId = x.FeeId;
            return c;
        }

        public static CashAccountRcrViewDto RcrView(CashAccount obj)
        {
            var dto = new CashAccountRcrViewDto();
            dto.Amount = obj.Amount;
            dto.CompanyName = obj.Fee.Policy.Risk.Company.Name;
            dto.PolicyNumber = obj.Fee.Policy.Number;
            dto.ReceiptNumber = obj.ReceiptNumber;
            dto.RecordDate = obj.Date.ToString("yyyy-MM-dd");
            return dto;
        }
    }
}
