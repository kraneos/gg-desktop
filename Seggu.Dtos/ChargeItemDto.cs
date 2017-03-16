using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class ChargeItemDto
    {
        public string PolicyNumber { get; set; }
        public string FeeNumber { get; set; }
        public decimal Value { get; set; }
    }
}
