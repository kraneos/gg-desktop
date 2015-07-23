using Seggu.Dtos;
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

        //void Update(CashAccountDto x);
        //void Delete(string id);
    }
}
