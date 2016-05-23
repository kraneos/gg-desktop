using System;
using System.Collections.Generic;

namespace Seggu.Dtos
{
    [Serializable]
    public class CompanyFullDto : KeyValueDto
    {
        public bool Active { get; set; }
        public string Phone { get; set; }
        public string CUIT { get; set; }
        public string LiqDay1 { get; set; }
        public string LiqDay2 { get; set; }
        public string Convenio1 { get; set; }
        public string Convenio2 { get; set; }
        public string Notes { get; set; }
        public string Mail { get; set; }
        public List<ContactDto> Contacts { get; set; }
        public List<ProducerCompanyDto> Producers { get; set; }
        public List<RiskCompanyDto> Risks { get; set; }
        public List<CoverageDto> Coverages { get; set; }
    }
}
