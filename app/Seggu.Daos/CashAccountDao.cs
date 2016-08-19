using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class CashAccountDao : IdParseEntityDao<CashAccount>, ICashAccountDao
    {
        public CashAccountDao()
            : base()
        {
        }

        public List<CashAccount> GetRcrView(DateTime from, DateTime to)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.CashAccounts
                       .Include("Fee")
                       .Include("Fee.Policy")
                       .Include("Fee.Policy.Risk")
                       .Include("Fee.Policy.Risk.Company")
                       .Where(ca => ca.Date > from && ca.Date < to && ca.FeeId != null).ToList();
            }
        }

        public List<CashAccount> GetOverdue(DateTime time)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.CashAccounts
                       .Include("Fee")
                       .Include("Fee.Policy")
                       .Include("Fee.Policy.Risk")
                       .Include("Fee.Policy.Risk.Company")
                       .Where(ca => ca.Date < time && ca.FeeId == null).ToList();
            }
        }

        public bool ReceiptExists(string receiptNumber)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.CashAccounts.Any(x => x.ReceiptNumber == receiptNumber);
            }
        }

        public override void Update(CashAccount obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.CashAccounts.Find(obj.Id);
                Mapper.Map<CashAccount, CashAccount>(obj, orig);
                context.SaveChanges();
            }
        }
    }
}
