using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services
{
    public sealed class BankService : IBankService
    {
        private IBankDao bankDao;

        public BankService(IBankDao bankDao)
        {
            this.bankDao = bankDao;
        }

        public IEnumerable<BankDto> GetAll()
        {
            var banks = this.bankDao.GetAll().OrderBy(b => b.Name);
            return
                from b in banks
                select BankDtoMapper.GetDto(b);
        }

        public void Save(BankDto bank)
        {
            this.bankDao.Save(BankDtoMapper.GetBank(bank));
        }

        public void Update(BankDto bank)
        {
            this.bankDao.Update(BankDtoMapper.GetBankUpdate(bank));
        }

        public void Delete(string id)
        {
            try
            {
                var guid = new Guid(id);
                bankDao.Delete(guid);
            }
            catch
            {
                throw;
            }
        }


        public bool ExistNumber(string number)
        {
           return bankDao.GetByNumber(number);

        }

        public bool ExistName(string name)
        {
            return bankDao.GetByName(name);
        }
    }
}
