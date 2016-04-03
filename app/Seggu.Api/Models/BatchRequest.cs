using Seggu.Api.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Seggu.Api.Models
{
    [DataContract]
    public class BatchRequest<T> where T : IdEntity
    {
        public BatchRequest()
        {
            this.Requests = new List<BatchElement<T>>();
        }
        [DataMember]
        [Required]
        public IEnumerable<BatchElement<T>> Requests { get; set; }
    }
}