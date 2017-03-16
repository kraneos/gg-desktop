using Parse;
using System;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Fee")]
    public class FeeVM : ViewModel
    {
        [ParseFieldName("policy")]
        public ParseObject Policy { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("expirationDate")]
        public System.DateTime ExpirationDate { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("number")]
        public int Number { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("value")]
        public double Value { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("balance")]
        public double Balance { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("companyPayment")]
        public double CompanyPayment { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("annulated")]
        public bool Annulated { get { return GetProperty<bool>(); } set { SetProperty<bool>(value); } }
        [ParseFieldName("feeSelection")]
        public ParseObject FeeSelection { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("state")]
        public int State { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("endorse")]
        public ParseObject Endorse { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("registeredLiqDate")]
        public string RegisteredLiqDate { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
    }
}