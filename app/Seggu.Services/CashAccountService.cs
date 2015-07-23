using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
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
    }
}
