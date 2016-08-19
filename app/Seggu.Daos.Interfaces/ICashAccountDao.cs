using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICashAccountDao : IParseIdEntityDao<CashAccount>
    {
        List<CashAccount> GetRcrView(System.DateTime from, System.DateTime to);

        bool ReceiptExists(string receipt);

        List<CashAccount> GetOverdue(DateTime time);
    }
}
