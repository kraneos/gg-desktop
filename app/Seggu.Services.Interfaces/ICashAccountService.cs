using Seggu.Dtos;
using Seggu.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.Interfaces
{
     public interface ICashAccountService
    {
        IEnumerable<CashAccountDto> GetAll();

        void Save(CashAccountDto x);

        IEnumerable<CashAccountRcrViewDto> GetRcrView(DateTime from, DateTime to);

        bool ReceiptExists(string receipt);

        IEnumerable<CashAccountRcrViewDto> GetOverdue(DateTime time);
    }
}
