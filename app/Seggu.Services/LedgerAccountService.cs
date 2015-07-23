using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class LedgerAccountService : ILedgerAccountService
    {
        private ILedgerAccountDao ledgerAccountDao;
        public LedgerAccountService(ILedgerAccountDao ledgerAccountDao)
        {
            this.ledgerAccountDao = ledgerAccountDao;
        }

        public IEnumerable<LedgerAccountDto> GetAll()
        {
            var ledgerAccounts = this.ledgerAccountDao.GetAll().OrderBy(x => x.Name);
            return
                from x in ledgerAccounts
                select LedgerAccountDtoMapper.GetDto(x);
        }

        public string GetCobranzaId()
        {
            return ledgerAccountDao.GetCobranzaId();
        }

        public void Create (LedgerAccountDto la)
        {
            ledgerAccountDao.Save(LedgerAccountDtoMapper.GetObject(la));
        }
    }
}
