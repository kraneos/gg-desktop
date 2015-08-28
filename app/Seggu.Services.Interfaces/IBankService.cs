using Seggu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.Interfaces
{
    public interface IBankService
    {
        IEnumerable<BankDto> GetAll();
        void Save(BankDto bank);
        void Update(BankDto bank);
        void Delete(int id);
        bool ExistNumber(string number);
        bool ExistName(string name);
        bool HasAssociatedRecords(int id);
    }
}
