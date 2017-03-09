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

        public void Delete(int id)
        {
            var guid = id;
            bankDao.Delete(guid);
        }


        public bool ExistNumber(string number)
        {
            return bankDao.GetByNumber(number);

        }

        public bool ExistName(string name)
        {
            return bankDao.GetByName(name);
        }


        public bool HasAssociatedRecords(int id)
        {
            if (id != default(int))
            {
                var guid = id;
                var hasCheques = this.bankDao.GetContainer().Cheques.Any(x => x.BankId == guid);
                var hasCreditCards = this.bankDao.GetContainer().ClientCreditCards.Any(x => x.BankId == guid);

                return hasCheques || hasCreditCards;
            }

            return false;
        }
    }
}
