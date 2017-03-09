using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface ICashAccountDao : IParseIdEntityDao<CashAccount>
    {
        IEnumerable<CashAccount> GetRcrView(System.DateTime from, System.DateTime to);

        bool ReceiptExists(string receipt);

        IEnumerable<CashAccount> GetOverdue(DateTime time);
    }
}
