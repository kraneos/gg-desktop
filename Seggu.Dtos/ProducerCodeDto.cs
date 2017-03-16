using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class ProducerCodeDto
    {
        public int ProducerId { get; set; }
        public int CompanyId { get; set; }
        public string Code { get; set; }
    }
}
