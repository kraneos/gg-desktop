using Seggu.Domain;
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
            dto.Id = (int)la.Id;
            dto.Name = la.Name;
            return dto;
        }

        public static LedgerAccount GetObject(LedgerAccountDto la)
        {
            var obj = new LedgerAccount();
            obj.Id = la.Id;
            obj.Name = la.Name;
            return obj;
        }
    }
}
