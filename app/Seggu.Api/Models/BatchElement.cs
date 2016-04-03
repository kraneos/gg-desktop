using Seggu.Api.Domain;
using System;

namespace Seggu.Api.Models
{
    public class BatchElement<T> where T : IdEntity
    {
        public string Method { get; set; }
        public Guid? Id { get; set; }
        public T Body { get; set; }
    }
}