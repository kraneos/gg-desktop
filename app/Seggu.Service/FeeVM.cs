using System;
using System.Runtime.Serialization;

namespace Seggu.Service
{
    [DataContract]
    public class FeeVM
    {
        //[DataMember(Name = "amount")]
        public decimal Amount { get; set; }
        //[DataMember(Name = "date")]
        public DateTime Date { get; set; }
    }
}