using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class CompanyDto:KeyValueDto
    {
        public string CUIT { get; set; }
        public string Mail { get; set; }
        public string Notes { get; set; }
        public string Phone { get; set; }
        public string LiqDay1 { get; set; }
        public string LiqDay2 { get; set; }
        public string Convenio1 { get; set; }
        public string Convenio2 { get; set; }
        public bool Active { get; set; }
    }
}
