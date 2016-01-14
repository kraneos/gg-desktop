using System;

namespace Seggu.Service
{
    public class PolicyVM
    {
        public string ObjectId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LocallyUpdatedAt { get; set; }
        public long Id { get; set; }
        public string Number { get; set; }
        public decimal Value { get; set; }
        public int FeeAmount { get; set; }
        public string ClientName { get; set; }
    }
}