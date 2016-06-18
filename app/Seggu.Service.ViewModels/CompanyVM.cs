using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Company")]
    public class CompanyVM : KeyValueViewModel
    {
        [ParseFieldName("phone")]
        public string Phone { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("notes")]
        public string Notes { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("active")]
        public bool Active { get { return GetProperty<bool>(); } set { SetProperty<bool>(value); } }
        [ParseFieldName("email")]
        public string EMail { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("cuit")]
        public string CUIT { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("liqDay1")]
        public int LiqDay1 { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("liqDay2")]
        public int LiqDay2 { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("paymentDay1")]
        public int PaymentDay1 { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("paymentDay2")]
        public int PaymentDay2 { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }

    }
}
