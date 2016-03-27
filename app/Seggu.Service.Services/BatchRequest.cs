using Seggu.Service.ViewModels;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Seggu.Service.Services
{
    [DataContract]
    public class BatchRequest<T> where T : ParseViewModel
    {
        [DataMember]
        public IEnumerable<BatchElement<T>> Requests { get; set; }
    }
}