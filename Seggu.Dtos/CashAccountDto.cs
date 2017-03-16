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
        public int AssetId { get; set; }
        public int ProducerId { get; set; }
        public int LedgerAccountId { get; set; }
        public string AssetName { get; set; }
        public string LedgerAccountName { get; set; }
        public int FeeId { get; set; }
    }
}
