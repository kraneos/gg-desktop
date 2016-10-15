using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Dtos
{
    public class PolicyRosViewDto
    {
        public string EmissionDate { get; set; }
        public string ClientDocument { get; set; }
        public string ClientFullName { get; set; }
        public string ClientAddressPostalCode { get; set; }
        public string ClientAddressLine { get; set; }
        public string RiskType { get; set; }
        public decimal Value { get; set; }
        public string StartDate { get; set; }
        public string Number { get; set; }
        public string EndDate { get; set; }
    }
}
