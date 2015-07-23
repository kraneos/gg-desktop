using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class CashAccountDto : EntityWithIdDto
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }

        public string ReceiptNumber { get; set; }
        public string AssetId { get; set; }
        public string ProducerId { get; set; }
        public string LedgerAccountId { get; set; }
        public string AssetName { get; set; }
        public string LedgerAccountName { get; set; }
        public string FeeId { get; set; }
    }
}
