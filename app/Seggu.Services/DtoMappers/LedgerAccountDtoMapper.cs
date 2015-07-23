using Seggu.Data;
using Seggu.Dtos;
using System;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class LedgerAccountDtoMapper
    {
        public static LedgerAccountDto GetDto(LedgerAccount la)
        {
            var dto = new LedgerAccountDto();
            dto.Id = la.Id.ToString();
            dto.Name = la.Name;
            return dto;
        }

        public static LedgerAccount GetObject(LedgerAccountDto la)
        {
            var obj = new LedgerAccount();
            obj.Id = string.IsNullOrEmpty(la.Id) ? Guid.Empty : new Guid(la.Id);
            obj.Name = la.Name;
            return obj;
        }
    }
}
