using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("FeeSelection")]
    public class FeeSelectionVM : KeyValueViewModel
    {
        [ParseFieldName("total")]
        public double Total { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("liquidation")]
        public ParseObject Liquidation { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("notes")]
        public string Notes { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
    }
}
