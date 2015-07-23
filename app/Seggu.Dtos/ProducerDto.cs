using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class ProducerDto : KeyValueDto
    {
        public string Matrícula { get; set; }

        public bool Cobrador { get; set; }
    }
}
