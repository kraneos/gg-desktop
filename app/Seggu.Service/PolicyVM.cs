using System;

namespace Seggu.Service
{
    public class PolicyVM
    {
        public string ObjectId { get; set; }
        public DateVM CreatedAt { get; set; }
        public DateVM UpdatedAt { get; set; }
        public DateVM LocallyUpdatedAt { get; set; }
        public long Id { get; set; }
        public string Number { get; set; }
        public decimal Value { get; set; }
        public int FeeAmount { get; set; }
        public string ClientName { get; set; }
        public DateVM StartDate { get; set; }
        public DateVM EndDate { get; set; }
        public long ClientId { get; set; }
    }
}