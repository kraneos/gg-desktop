using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public class ChequeVM : ViewModel
    {
        public string Number { get; set; }
        public string BankId { get; set; }
        public decimal Value { get; set; }
        public System.DateTime Date { get; set; }
    }
}
