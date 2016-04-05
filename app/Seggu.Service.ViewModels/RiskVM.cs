using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class RiskVM : KeyValueViewModel
    {
        public int RiskType { get; set; }
        public Guid CompanyId { get; set; }
    }
}
