using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class CompanyVM : KeyValueViewModel
    {
        public string Phone { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }
        public string EMail { get; set; }
        public string CUIT { get; set; }
        public int LiqDay1 { get; set; }
        public int LiqDay2 { get; set; }
        public int PaymentDay1 { get; set; }
        public int PaymentDay2 { get; set; }

    }
}
