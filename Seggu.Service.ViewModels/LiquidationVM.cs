using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Liquidation")]
    public class LiquidationVM : ViewModel
    {
        [ParseFieldName("date")]
        public System.DateTime Date { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("total")]
        public double Total { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("receptionDate")]
        public Nullable<System.DateTime> ReceptionDate { get { return GetProperty<Nullable<System.DateTime>>(); } set { SetProperty<Nullable<System.DateTime>>(value); } }
        [ParseFieldName("registered")]
        public bool Registered { get { return GetProperty<bool>(); } set { SetProperty<bool>(value); } }
        [ParseFieldName("notes")]
        public string Notes { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("company")]
        public ParseObject Company { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
    }
}
