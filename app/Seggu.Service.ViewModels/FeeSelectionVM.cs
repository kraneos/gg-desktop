using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class FeeSelectionVM : KeyValueViewModel
    {
        public decimal Total { get; set; }
        public string LiquidationId { get; set; }
        public string Notes { get; set; }
    }
}
