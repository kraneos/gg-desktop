using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Cheque")]
    public class ChequeVM : ViewModel
    {
        [ParseFieldName("number")]
        public string Number { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        //[ParseFieldName("bankId")]
        //public string BankId { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("bank")]
        public ParseObject Bank { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("value")]
        public double Value { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("date")]
        public System.DateTime Date { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
    }
}
