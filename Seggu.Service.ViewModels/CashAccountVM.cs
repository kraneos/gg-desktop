using Parse;
using System;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("CashAccount")]
    public class CashAccountVM : ViewModel
    {
        [ParseFieldName("asset")]
        public AssetVM Asset { get { return GetProperty<AssetVM>(); } set { SetProperty<AssetVM>(value); } }
        [ParseFieldName("ledgerAccount")]
        public LedgerAccountVM LedgerAccount { get { return GetProperty<LedgerAccountVM>(); } set { SetProperty<LedgerAccountVM>(value); } }
        [ParseFieldName("date")]
        public System.DateTime Date { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("description")]
        public string Description { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("amount")]
        public double Amount { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("balance")]
        public double Balance { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("producer")]
        public ProducerVM Producer { get { return GetProperty<ProducerVM>(); } set { SetProperty<ProducerVM>(value); } }
        [ParseFieldName("fee")]
        public FeeVM Fee { get { return GetProperty<FeeVM>(); } set { SetProperty<FeeVM>(value); } }
        [ParseFieldName("receiptNumber")]
        public string ReceiptNumber { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
    }
}
