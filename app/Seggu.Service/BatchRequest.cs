using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Seggu.Service
{
    [DataContract]
    public class BatchRequest<T> where T : new()
    {
        [DataMember]
        public IEnumerable<BatchElement<T>> Requests { get; set; }
    }
}