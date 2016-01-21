using System;
using System.Runtime.Serialization;

namespace Seggu.Service
{
    public class FeeVM
    {
        public string ObjectId { get; set; }
        public DateVM CreatedAt { get; set; }
        public DateVM UpdatedAt { get; set; }
        public DateVM LocallyUpdatedAt { get; set; }
        public long Id { get; set; }
        public int Number { get; set; }
        public decimal Value { get; set; }
        public int State { get; set; }
        public DateVM ExpirationDate { get; set; }
        public string PolicyId { get; set; }
        public PointerVM Policy { get; set; }
        public string StateName { get; set; }
    }
}