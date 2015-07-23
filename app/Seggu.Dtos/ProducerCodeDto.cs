using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class ProducerCodeDto
    {
        public string ProducerId { get; set; }
        public string CompanyId { get; set; }
        public string Code { get; set; }
    }
}
