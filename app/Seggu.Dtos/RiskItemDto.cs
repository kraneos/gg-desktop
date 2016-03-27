using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Dtos
{
    public class RiskItemDto : KeyValueDto
    {
        public RiskType RiskType { get; set; }
    }
}
