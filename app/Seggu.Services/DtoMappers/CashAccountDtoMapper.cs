using Seggu.Data;
using Seggu.Dtos;
using System;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class CashAccountDtoMapper
    {
        public static CashAccountDto GetDto(CashAccount x)
        {
            var dto = new CashAccountDto();
            dto.Id = x.Id.ToString();
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
            dto.Id = x.Id.ToString();
            return dto;
        }
        public static CashAccount GetObject(CashAccountDto x)
        {
            var c = new CashAccount();
            c.Id = string.IsNullOrEmpty(x.Id) ? Guid.Empty : new Guid(x.Id); 
            c.Amount = x.Amount;
            c.AssetId = string.IsNullOrEmpty(x.AssetId) ? Guid.Empty : new Guid(x.AssetId);
            c.Balance = x.Balance;
            c.Date = x.Date;
            c.Description = x.Description;
            c.ReceiptNumber = x.ReceiptNumber;
            c.LedgerAccountId = string.IsNullOrEmpty(x.LedgerAccountId) ? Guid.Empty : new Guid(x.LedgerAccountId);
            c.ProducerId = string.IsNullOrEmpty(x.ProducerId) ? Guid.Empty : new Guid(x.ProducerId);
            c.FeeId = string.IsNullOrEmpty(x.FeeId) ? (Guid?)null : new Guid(x.FeeId);
            return c;
        }
    }
}
