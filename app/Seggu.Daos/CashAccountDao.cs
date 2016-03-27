using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class CashAccountDao : IdParseEntityDao<CashAccount> , ICashAccountDao
    {
        public CashAccountDao(SegguDataModelContext context)
            : base(context)
        {
        }

        public IEnumerable<CashAccount> GetRcrView(DateTime from, DateTime to)
        {
            return this.context.CashAccounts
                .Include("Fee")
                .Include("Fee.Policy")
                .Include("Fee.Policy.Risk")
                .Include("Fee.Policy.Risk.Company")
                .Where(ca => ca.Date > from && ca.Date < to && ca.FeeId != null);
        }

        public IEnumerable<CashAccount> GetOverdue(DateTime time)
        {
            return this.context.CashAccounts
                .Include("Fee")
                .Include("Fee.Policy")
                .Include("Fee.Policy.Risk")
                .Include("Fee.Policy.Risk.Company")
                .Where(ca => ca.Date < time && ca.FeeId == null);
        }

        public bool ReceiptExists(string receipt)
        {
            return this.Set.Any(x => x.ReceiptNumber == receipt);
        }
    }
}
