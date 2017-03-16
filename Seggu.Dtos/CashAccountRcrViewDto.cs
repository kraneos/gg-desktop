using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.Dtos
{
    public class CashAccountRcrViewDto
    {
        public string RecordDate { get; set; }
        public string ReceiptNumber { get; set; }
        public string PolicyNumber { get; set; }
        public decimal Amount { get; set; }
        public string CompanyName { get; set; }
    }
}
