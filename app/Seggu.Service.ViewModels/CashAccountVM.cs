using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("CashAccount")]
    public class CashAccountVM : ViewModel
    {
        [ParseFieldName("asset")]
        public ParseObject Asset { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("ledgerAccount")]
        public ParseObject LedgerAccount { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("date")]
        public System.DateTime Date { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("description")]
        public string Description { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("amount")]
        public double Amount { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("balance")]
        public double Balance { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("producer")]
        public ParseObject Producer { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("fee")]
        public ParseObject Fee { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("receiptNumber")]
        public string ReceiptNumber { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
    }
}
