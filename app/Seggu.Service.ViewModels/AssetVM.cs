using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Asset")]
    public class AssetVM : KeyValueViewModel
    {
        [ParseFieldName("amount")]
        public double Amount
        {
            get { return GetProperty<double>(); }
            set { SetProperty<double>(value); }
        }
    }
}