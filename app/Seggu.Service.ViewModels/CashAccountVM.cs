using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class CashAccountVM : ViewModel
    {
        public Guid AssetId { get; set; }
        public Guid LedgerAccountId { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public Nullable<Guid> ProducerId { get; set; }
        public Nullable<long> FeeId { get; set; }
        public string ReceiptNumber { get; set; }
    }
}
