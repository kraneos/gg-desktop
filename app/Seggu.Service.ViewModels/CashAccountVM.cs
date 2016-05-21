using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class CashAccountVM : ViewModel
    {
        public string AssetId { get; set; }
        public string LedgerAccountId { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string ProducerId { get; set; }
        public string FeeId { get; set; }
        public string ReceiptNumber { get; set; }
    }
}
