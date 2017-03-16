using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Dtos
{
    public class FeeIndexDto
    {
        public string FeeNumber { get; set; }
        public decimal FeeValue { get; set; }
        public string PolicyNumber { get; set; }
        public string ClientName { get; set; }
    }
}
