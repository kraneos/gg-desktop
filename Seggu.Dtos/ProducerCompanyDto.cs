using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class ProducerCompanyDto : KeyValueDto
    {
        public string Code { get; set; }
        public string RegistrationNumber { get; set; }
        public float commission { get; set; }
    }
}
