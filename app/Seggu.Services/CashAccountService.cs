using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Dtos;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class CashAccountService : ICashAccountService
    {
        private ICashAccountDao cashAccountDao;

        public CashAccountService(ICashAccountDao cashAccountDao)
        {
            this.cashAccountDao = cashAccountDao;
        }

        public IEnumerable<CashAccountDto> GetAll()
        {
            var cashAccounts = this.cashAccountDao.GetAll();
            return cashAccounts.OrderByDescending(x => x.Date).Select(b => CashAccountDtoMapper.GetDto(b));
        }
        
        public void Save(CashAccountDto x)
        {
            this.cashAccountDao.Save(CashAccountDtoMapper.GetObject(x));
        }

        public IEnumerable<CashAccountRcrViewDto> GetRcrView(DateTime from, DateTime to)
        {
            var producers = this.cashAccountDao.GetRcrView(from, to);
            return producers.Select(x => CashAccountDtoMapper.RcrView(x));
        }

        public bool ReceiptExists(string receipt)
        {
            return this.cashAccountDao.ReceiptExists(receipt);
        }

        public IEnumerable<CashAccountRcrViewDto> GetOverdue(DateTime time)
        {
            var cas = this.cashAccountDao.GetOverdue(time).ToList();
            return cas.Select(c => CashAccountDtoMapper.RcrView(c));
        }
    }
}
