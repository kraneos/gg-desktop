using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class LiquidationVM : ViewModel
    {
        public System.DateTime Date { get; set; }
        public decimal Total { get; set; }
        public Nullable<System.DateTime> ReceptionDate { get; set; }
        public bool Registered { get; set; }
        public string Notes { get; set; }
        public string CompanyId { get; set; }

    }
}
